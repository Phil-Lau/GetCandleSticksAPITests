using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GetCandleSticksAPITests
{
    public class RequestClient
    {
        //private readonly Uri baseUrl;

        public static async Task<SuccessResponse> Get(string instrumentName, string timeFrame)
        {
            var baseUrl = new Uri("https://api.crypto.com/v2/public/get-candlestick");

            using (var client = new HttpClient())
            {

                client.BaseAddress = baseUrl;
                var requestUri = new Uri($"?instrument_name={instrumentName}&timeframe={timeFrame}", UriKind.Relative);
                var result = client.GetAsync(requestUri).Result.Content.ReadAsStringAsync().Result;
                return client.GetFromJsonAsync<SuccessResponse>(requestUri).Result;
            }
        }

    }
}
