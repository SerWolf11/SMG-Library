using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LibKo.ServiceConnection
{
    public class Settings
    {
        public static HttpClient ClientProperties()
        {
            var client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiURL"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.MaxResponseContentBufferSize = 1024 * 1024 * 1024;
                client.Timeout = TimeSpan.FromMinutes(30.00);
            }
            catch (Exception)
            {
                throw;
            }
            return client;
        }

        public static HttpClient ClientProperties(String Setting)
        {
            var client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Setting]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.MaxResponseContentBufferSize = 1024 * 1024 * 1024;
                client.Timeout = TimeSpan.FromMinutes(30.00);
            }
            catch (Exception)
            {
                throw;
            }
            return client;
        }
    }
}
