using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using WebRelayer.Helpers;

namespace WebRelayer.Services
{
    public class AlaricMonitorHttpClient:IHttpClient
    {
        private readonly HttpClient _httpClient;

        public AlaricMonitorHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept-Client", "Alaric-Monitor");
        }

        public async Task<T> SendGetAsync<T>(string requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl);

            response.EnsureSuccessStatusCode();

            return await HttpContentToObject<T>(response.Content);
        }

        public async Task<T> SendPostAsync<T>(string requestUrl, object obj)
        {
            var response = await _httpClient.PostAsJsonAsync(requestUrl, obj);

            response.EnsureSuccessStatusCode();

            return await HttpContentToObject<T>(response.Content);
        }

        private async Task<T> HttpContentToObject<T>(HttpContent content)
        {
            return await content.ReadAsAsync<T>(new[] { new JsonMediaTypeFormatter() });
        }
    }
}
