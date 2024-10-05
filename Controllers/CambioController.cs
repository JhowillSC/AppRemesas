using Microsoft.AspNetCore.Mvc;
using AppRemesas.Services;
using System.Threading.Tasks;
using System.Text.Json;

namespace AppRemesas.Controllers
{
    public class CambioController : Controller
    { 
        private readonly CurrencyConversionService _currencyService;

        public CambioController(CurrencyConversionService currencyService)
        {
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
       public async Task<decimal> GetBTCToUSDEExchangeRate()
        {
            var client = new HttpClient(); 
            var response = await client.GetStreamAsync("https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd");
    
             
            var price = await JsonSerializer.DeserializeAsync<Dictionary<string, Dictionary<string, decimal>>>(response);
    
            return price["bitcoin"]["usd"]; 
        }
    }
}