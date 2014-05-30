using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LibKo.WAPI
{
    public class ServiceData
    {
        private static HttpClient _clientProperties = Settings.ClientProperties();

        public static HttpClient ClientProperties
        {
            get { return ServiceData._clientProperties; }
            set { ServiceData._clientProperties = value; }
        }


    }
}
