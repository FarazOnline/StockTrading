using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockTrader.API
{
    public class ApiHttpClient : HttpClient
    {
        public ApiHttpClient()
        {
            BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
