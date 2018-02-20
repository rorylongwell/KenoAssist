using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Keno.Consumer
{
    public class CoreHttpClient: HttpClient
    {
        public CoreHttpClient(string baseUri)
        {
            BaseAddress = new Uri(baseUri);
            //Timeout = new TimeSpan(600000);// 1 minutes //temporary comment because it causes Exception on GetAsync
            
            DefaultRequestHeaders.Accept.Clear();
            //DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

   
}
