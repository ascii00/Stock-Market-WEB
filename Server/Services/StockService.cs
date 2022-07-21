using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace StockMarket.Server.Services
{
    public class StockService : IStockService
    {
        
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        
        public StockService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        private async Task<string> SendGetRequestAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
        }
    }
}