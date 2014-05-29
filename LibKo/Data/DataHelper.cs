using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.ComponentModel;

namespace LibKo.Data
{
    public class DataHelper
    {
        public static DataTable ToDataTable<T>(List<T> data)
            where T: new()
        {
            var props =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            for (var i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            var values = new object[props.Count];

            foreach (T item in data)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
