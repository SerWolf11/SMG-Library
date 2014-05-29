using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using LibKo.ServiceConnection;

namespace LibKo.WAPI
{
    public class WP<T>
        where T: new()
    {
        public WP()
        {
            var comodin = new T();
        }

        public static List<T> GetList(Type tipo)
        {
            var Lista = new List<T>();

            var url = tipo.Name;
            var response = ServiceData.ClientProperties.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                Lista = lista.ToList();
            }

            return Lista;
        }

        public static List<T> GetList(String URI)
        {
            var Lista = new List<T>();

            var url = URI;
            var response = ServiceData.ClientProperties.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                Lista = lista.ToList();
            }

            return Lista;
        }

        public static List<T> GetList(Type tipo, String URI)
        {
            var Lista = new List<T>();

            var url = tipo.Name + URI;
            var response = ServiceData.ClientProperties.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                Lista = lista.ToList();
            }

            return Lista;
        }

        public static T Get(Type tipo, String URI)
        {
            var Lista = new T();

            var url = tipo.Name + URI;
            var response = ServiceData.ClientProperties.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<T>().Result;
                Lista = lista;
            }

            return Lista;
        }

        public static T Get(Type tipo)
        {
            var Lista = new T();

            var url = tipo.Name;
            var response = ServiceData.ClientProperties.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<T>().Result;
                Lista = lista;
            }

            return Lista;
        }

        public static T Get(String URI)
        {
            var Lista = new T();

            var url = URI;
            var response = ServiceData.ClientProperties.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<T>().Result;
                Lista = lista;
            }

            return Lista;
        }

        public static T Post<S>(S s)
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name;
                var response = ServiceData.ClientProperties.PostAsJsonAsync(url, s).Result;

                if (response.IsSuccessStatusCode)
                {
                    var _ID = response.Content.ReadAsAsync<T>().Result;
                    ID = _ID;
                }
            }
            catch (HttpRequestException e)
            {
                ID = new T();
            }
            return ID;
        }

        public static T Post<S>(S s, String URI)
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name + URI;
                var response = ServiceData.ClientProperties.PostAsJsonAsync(url, s).Result;

                if (response.IsSuccessStatusCode)
                {
                    var _ID = response.Content.ReadAsAsync<T>().Result;
                    ID = _ID;
                }
            }
            catch (HttpRequestException e)
            {
                ID = new T();
            }
            return ID;
        }

        public static T Post<S>(String URI, S s)
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = URI;
                var response = ServiceData.ClientProperties.PostAsJsonAsync(url, s).Result;

                if (response.IsSuccessStatusCode)
                {
                    var _ID = response.Content.ReadAsAsync<T>().Result;
                    ID = _ID;
                }
            }
            catch (HttpRequestException e)
            {
                ID = new T();
            }
            return ID;
        }

        public static T Put<S>(S s)
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name;
                var response = ServiceData.ClientProperties.PutAsJsonAsync(url, s).Result;

                if (response.IsSuccessStatusCode)
                {
                    var _ID = response.Content.ReadAsAsync<T>().Result;
                    ID = _ID;
                }
            }
            catch (HttpRequestException e)
            {
                ID = new T();
            }
            return ID;
        }

        public static T Put<S>(S s, String URI)
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name + URI;
                var response = ServiceData.ClientProperties.PutAsJsonAsync(url, s).Result;

                if (response.IsSuccessStatusCode)
                {
                    var _ID = response.Content.ReadAsAsync<T>().Result;
                    ID = _ID;
                }
            }
            catch (HttpRequestException e)
            {
                ID = new T();
            }
            return ID;
        }

        public static T Put<S>(String URI, S s)
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = URI;
                var response = ServiceData.ClientProperties.PutAsJsonAsync(url, s).Result;

                if (response.IsSuccessStatusCode)
                {
                    var _ID = response.Content.ReadAsAsync<T>().Result;
                    ID = _ID;
                }
            }
            catch (HttpRequestException e)
            {
                ID = new T();
            }
            return ID;
        }


        public static S Delete<S>(String URI)
            where S: new()
        {
            var s = new S();
            try
            {
                var url = URI;
                var response = ServiceData.ClientProperties.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    s = response.Content.ReadAsAsync<S>().Result;
                }
            }
            catch (HttpRequestException e)
            {
                s = new S();
            }
            return s;
        }
        public static Boolean Delete(String URI)
        {
            var s = false;
            try
            {
                var url = URI;
                var response = ServiceData.ClientProperties.DeleteAsync(url).Result;

                s = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                s = false;
            }
            return s;
        }

        private int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
            private set
            {
                count = value;
            }
        }

        private List<Object> _History = new List<Object>();

        public List<Object> History
        {
            get
            {
                return _History;
            }
            set
            {
                _History = value;
            }
        }
    }
}
