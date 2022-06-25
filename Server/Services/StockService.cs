using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StockMarket.Shared.Models;

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
        
        public async Task<string> GetTickers()
        {
            List<Ticker> tickers = null;
            var API_KEY = _configuration["API_KEY"];
            var url = $"https://api.polygon.io/v3/reference/tickers?active=true&sort=ticker&order=asc&apiKey={API_KEY}";
            string json = await SendGetRequestAsync(url);
            return json;
            
        }
        
        private async Task<string> SendGetRequestAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
        }
    }
}