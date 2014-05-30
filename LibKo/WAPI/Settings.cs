using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections;

namespace LibKo.WAPI
{
    public static class Settings
    {
        public static Boolean setDefaultClient(this HttpClient client)
        {
            Boolean flag = false;

            ServiceData.ClientProperties = client;

            if (client == ServiceData.ClientProperties)
                flag = true;
            else
                flag = false;

            return flag;
        }

        public static HttpClient ClientProperties()
        {
            HttpClient client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiURL"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "Farmacia", "12345679890"))));
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
            HttpClient client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Setting]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "Farmacia", "12345679890"))));
                client.MaxResponseContentBufferSize = 1024 * 1024 * 1024;
                client.Timeout = TimeSpan.FromMinutes(30.00);
            }
            catch (Exception)
            {
                throw;
            }
            return client;
        }

        public static HttpClient ClientProperties(this HttpClient client, String Setting)
        {
             client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Setting]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "Farmacia", "12345679890"))));
                client.MaxResponseContentBufferSize = 1024 * 1024 * 1024;
                client.Timeout = TimeSpan.FromMinutes(30.00);
            }
            catch (Exception)
            {
                throw;
            }
            return client;
        }

        public static HttpClient ClientIP(String IP)
        {
            HttpClient client = new HttpClient();

            try
            {
                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Setting]);
                client.BaseAddress = new Uri(IP + "API");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "Farmacia", "12345679890"))));
                client.MaxResponseContentBufferSize = 1024 * 1024 * 1024;
                client.Timeout = TimeSpan.FromMinutes(30.00);
            }
            catch (Exception)
            {
                throw;
            }
            return client;
        }

        public static HttpClient ClientIP( this HttpClient client, String IP)
        {
             client = new HttpClient();

            try
            {
                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Setting]);
                client.BaseAddress = new Uri(IP+"API");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "Farmacia", "12345679890"))));
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
