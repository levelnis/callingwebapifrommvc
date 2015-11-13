namespace ApiHelper.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ApiClient : IApiClient
    {
        private const string BaseUri = "Http://localhost:28601/";

        public async Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                using (var content = new FormUrlEncodedContent(values))
                {
                    var query = await content.ReadAsStringAsync();
                    var requestUriWithQuery = string.Concat(requestUri, "?", query);
                    var response = await client.GetAsync(requestUriWithQuery);
                    return response;
                }
            }
        }
    }
}