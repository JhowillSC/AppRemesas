using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace AppRemesas.Services
{
    public class CurrencyConversionService
    {
        private readonly HttpClient _httpClient;

        public CurrencyConversionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetBTCToUSDEexchangeRate()
        {
            var response = await _httpClient.GetStreamAsync("https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd");
            var price = await JsonSerializer.DeserializeAsync<Dictionary<string, Dictionary<string, decimal>>>(response);
            return price["bitcoin"]["usd"];
        }
    }
}
