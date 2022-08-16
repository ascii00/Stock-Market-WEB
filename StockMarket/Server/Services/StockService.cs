using System.Net.Http;
using System.Threading.Tasks;

namespace StockMarket.Server.Services
{
    public class StockService : IStockService
    {
        
        private readonly HttpClient _httpClient;

        public StockService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<string?> GetJsonFromUrl(string url)
        {
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode) return null;
            return await result.Content.ReadAsStringAsync();
        }
    }
}