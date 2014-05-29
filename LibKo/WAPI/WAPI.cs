using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using LibKo.ServiceConnection;

namespace LibKo.WAPI
{
    public class WAPI
    {
        public static List<T> GetList<T>(String URI)
            where T: new()
        {
            var Lista = new List<T>();

            var url = URI;
            var response = Settings.ClientProperties().GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                Lista = lista.ToList();
            }

            return Lista;
        }
        public static T Get<T>(String URI)
            where T: new()
        {
            var Lista = new T();

            var url = URI;
            var response = Settings.ClientProperties().GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<T>().Result;
                Lista = lista;
            }

            return Lista;
        }
        public static T Get<T>(String URI, Boolean History)
            where T: new()
        {
            var Lista = new T();
            var flag = false;

            if (History)
            {
                foreach (var item in _History)
                {
                    if (Lista.GetType() == item.GetType())
                    {
                        flag = true;
                    }
                }
            }

            if (!flag)
            {
                var url = URI;
                var response = Settings.ClientProperties().GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var lista = response.Content.ReadAsAsync<T>().Result;
                    Lista = lista;
                }
                if (History)
                {
                    addToHistory(Lista);
                }
            }
            else
            {
                if (History)
                {
                    foreach (var item in _History)
                    {
                        if (Lista.GetType() == item.GetType())
                        {
                            try
                            {
                                Lista = (T)item;
                            }
                            catch (Exception)
                            {
                                var url = URI;
                                var response = Settings.ClientProperties().GetAsync(url).Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    var lista = response.Content.ReadAsAsync<T>().Result;
                                    Lista = lista;
                                }
                                if (History)
                                {
                                    addToHistory(Lista);
                                }
                            }
                        }
                    }
                }
            }
            return Lista;
        }

        public static T Get<T>(String ServiceName, params Parameters[] parameters)
            where T: new()
        {
            var Lista = new T();

            var url = ServiceName + "?";

            foreach (var item in parameters)
            {
                url = String.Format("{0}{1}={2}&", url, item.Name, item.ValueString);
            }
            url = url.Substring(0, url.Length - 1);
            var response = Settings.ClientProperties().GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<T>().Result;
                Lista = lista;
            }

            return Lista;
        }

        public static T Post<T, S>(S s)
            where T: new()
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name;
                var response = Settings.ClientProperties().PostAsJsonAsync(url, s).Result;

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

        public static T Post<T, S>(String URI, S s)
            where T: new()
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = URI;
                var response = Settings.ClientProperties().PostAsJsonAsync(url, s).Result;

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

        public static T Post<T, S>(S s, String URI)
            where T: new()
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name + URI;
                var response = Settings.ClientProperties().PostAsJsonAsync(url, s).Result;

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

        public static Boolean Post<S>(S s)
            where S: new()
        {
            var ID = false;
            try
            {
                var url = s.GetType().Name;
                var response = Settings.ClientProperties().PostAsJsonAsync(url, s).Result;

                ID = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                ID = false;
            }
            return ID;
        }
        public static Boolean Post<S>(String URI, S s)
            where S: new()
        {
            var ID = false;
            try
            {
                var url = URI;
                var response = Settings.ClientProperties().PostAsJsonAsync(url, s).Result;

                ID = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                ID = false;
            }
            return ID;
        }

        public static Boolean Post<S>(S s, String URI)
            where S: new()
        {
            var ID = false;
            try
            {
                var url = s.GetType().Name + URI;
                var response = Settings.ClientProperties().PostAsJsonAsync(url, s).Result;

                ID = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                ID = false;
            }
            return ID;
        }

        public static T Put<T, S>(S s)
            where T: new()
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name;
                var response = Settings.ClientProperties().PutAsJsonAsync(url, s).Result;

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

        public static T Put<T, S>(String URI, S s)
            where T: new()
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = URI;
                var response = Settings.ClientProperties().PutAsJsonAsync(url, s).Result;

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

        public static T Put<T, S>(S s, String URI)
            where T: new()
            where S: new()
        {
            var ID = new T();
            try
            {
                var url = s.GetType().Name + URI;
                var response = Settings.ClientProperties().PutAsJsonAsync(url, s).Result;

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

        public static Boolean Put<S>(S s)
            where S: new()
        {
            var ID = false;
            try
            {
                var url = s.GetType().Name;
                var response = Settings.ClientProperties().PutAsJsonAsync(url, s).Result;

                ID = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                ID = false;
            }
            return ID;
        }

        public static Boolean Put<S>(S s, String URI)
            where S: new()
        {
            var ID = false;
            try
            {
                var url = s.GetType().Name + URI;
                var response = Settings.ClientProperties().PutAsJsonAsync(url, s).Result;

                ID = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                ID = false;
            }
            return ID;
        }

        public static Boolean Put<S>(String URI, S s)
            where S: new()
        {
            var ID = false;
            try
            {
                var url = URI;
                var response = Settings.ClientProperties().PutAsJsonAsync(url, s).Result;

                ID = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                ID = false;
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
                var response = Settings.ClientProperties().DeleteAsync(url).Result;

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
                var response = Settings.ClientProperties().DeleteAsync(url).Result;

                s = response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                s = false;
            }
            return s;
        }

        private static Boolean addToHistory(Object val)
        {
            var flag = false;
            _History = (from x in _History
                                                where x.GetType() != val.GetType()
                                                select x).ToList();
            History.Add(val);
            Count = History.Count;
            return flag;
        }

        private static int count = 0;

        public static int Count
        {
            get
            {
                return WAPI.count;
            }
            private set
            {
                WAPI.count = value;
            }
        }

        private static List<Object> _History = new List<Object>();

        public static List<Object> History
        {
            get
            {
                return WAPI._History;
            }
            private set
            {
                WAPI._History = value;
            }
        }
    }
}
