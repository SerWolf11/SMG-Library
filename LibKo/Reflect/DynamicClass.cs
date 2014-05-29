using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Dynamic;
using System.Reflection.Emit;
using System.Reflection;

namespace LibKo.Reflect
{
    public class DynamicClass
    {
        public DynamicClass()
        {
        }

        public static void createType(string name, IDictionary<string, Type> props)
        {
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            var parameters = new CompilerParameters(new [] { "mscorlib.dll", "System.Core.dll" }, "Test.Dynamic.dll", false);
            parameters.GenerateExecutable = false;

            var compileUnit = new CodeCompileUnit();
            var ns = new CodeNamespace("Dynamic.Dynamic");
            compileUnit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));

            var classType = new CodeTypeDeclaration(name);
            classType.Attributes = MemberAttributes.Public;
            ns.Types.Add(classType);

            foreach (var prop in props)
            {
                var fieldName = "_" + prop.Key;
                var field = new CodeMemberField(prop.Value, fieldName);
                classType.Members.Add(field);

                var property = new CodeMemberProperty();
                property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                property.Type = new CodeTypeReference(prop.Value);
                property.Name = prop.Key;
                property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));
                property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));
                classType.Members.Add(property);
            }

            var results = csc.CompileAssemblyFromDom(parameters, compileUnit);
            results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
        }

        public static dynamic GetDynamicObject(Dictionary<string, object> properties)
        {
            var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
            foreach (var property in properties)
            {
                dynamicObject.Add(property.Key, property.Value);
            }
            return dynamicObject;
        }


        public DynamicClass Add<T>(string key, T value)
        {
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("Dynamic.dll");
            var typeBuilder = moduleBuilder.DefineType(Guid.NewGuid().ToString());
            typeBuilder.SetParent(this.GetType());
            var propertyBuilder = typeBuilder.DefineProperty(key, PropertyAttributes.None, typeof(T), Type.EmptyTypes);

            var getMethodBuilder = typeBuilder.DefineMethod("get_" + key, MethodAttributes.Public, CallingConventions.HasThis, typeof(T), Type.EmptyTypes);
            var getter = getMethodBuilder.GetILGenerator();
            getter.Emit(OpCodes.Ldarg_0);
            getter.Emit(OpCodes.Ldstr, key);
            getter.Emit(OpCodes.Callvirt, typeof(DynamicClass).GetMethod("Get", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(typeof(T)));
            getter.Emit(OpCodes.Ret);
            propertyBuilder.SetGetMethod(getMethodBuilder);

            var type = typeBuilder.CreateType();

            var child = (DynamicClass)Activator.CreateInstance(type);
            child.dictionary = this.dictionary;
            dictionary.Add(key, value);
            return child;
        }

        protected T Get<T>(string key)
        {
            return (T)dictionary[key];
        }

        private Dictionary<string, object> dictionary = new Dictionary<string, object>();
    }
}
