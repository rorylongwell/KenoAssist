using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Keno.Consumer
{
    public class ServiceConsumer
    {
        private readonly string baseUri;

        public ServiceConsumer(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public async Task<ResponseModel<TResponse>> GetAsync<TResponse>(string requestUri, bool runAsync = true)
        {

            using (var client = new CoreHttpClient(baseUri))
            {

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", D2I_CommonTypes.D2I_Sessions.Token);
                var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead)
                    .ContinueWith(r => ReadAsync<TResponse>(r.Result)).ConfigureAwait(runAsync);
                return await response;
            }
        }

        public ResponseModel<TResponse> Get<TResponse>(string requestUri)
        {
            using (var client = new CoreHttpClient(baseUri))
            {

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", D2I_CommonTypes.D2I_Sessions.Token);
                var response = client.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).Result;
                var result = ReadAsync<TResponse>(response).Result;
                return result;
            }
        }

        public async Task<ResponseModel<TResponse>> PostAsync<TResponse, TRequest>(string requestUri, TRequest request, bool runAsync = true)
        {
            using (var client = new CoreHttpClient(baseUri))
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", D2I_CommonTypes.D2I_Sessions.Token);
                var response = await client.PostAsJsonAsync(requestUri, request)
                    .ContinueWith(r => ReadAsync<TResponse>(r.Result)).ConfigureAwait(runAsync); ;
                return await response;
            }
        }

        public ResponseModel<TResponse> Post<TResponse, TRequest>(string requestUri, TRequest request, bool runAsync = false)
        {
            using (var client = new CoreHttpClient(baseUri))
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", D2I_CommonTypes.D2I_Sessions.Token);
                var response = client.PostAsJsonAsync(requestUri, request).Result;
                var result = ReadAsync<TResponse>(response).Result;
                return result;
            }
        }

        public ResponseModel<TResponse> Post<TResponse, TRequest>(string requestUri, HttpContent request, bool runAsync = false)
        {
            using (var client = new CoreHttpClient(baseUri))
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", D2I_CommonTypes.D2I_Sessions.Token);
                var response = client.PostAsync(requestUri, request).Result;
                var result = ReadAsync<TResponse>(response).Result;
                return result;
            }
        }

        private async Task<ResponseModel<TResponse>> ReadAsync<TResponse>(HttpResponseMessage response)
        {
            var result = new ResponseModel<TResponse>();
            var statusCode = response.StatusCode;
            try
            {
                if (response.IsSuccessStatusCode)
                    result.Error = false;
                result = await response.Content.ReadAsAsync<ResponseModel<TResponse>>(GetMediaTypeFormatters());                
            }
            catch (Exception)
            {
                // Temporary code when data return in not format of ResultModel
                result.Error = true;                
                result.Message = "Wrong Format! Data return: " + await response.Content.ReadAsStringAsync();                         
            }
            result.StatusCode = statusCode;
            return result;
        }

        private IEnumerable<MediaTypeFormatter> GetMediaTypeFormatters()
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            jsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            yield return jsonFormatter;
        }
    }
}
