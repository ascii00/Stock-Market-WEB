using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockMarket.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Globalization;

namespace StockMarket.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockChartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient = new();

        public StockChartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{ticker}")]
        public async Task<IEnumerable<StockChartData>> Get(string ticker)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            var dateYearBefore = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
        
            var apiKey = _configuration["ApiKey"];
            var url = $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/{dateYearBefore}/{dateNow}?adjusted=true&sort=asc&apiKey={apiKey}";
        
            var result = await _httpClient.GetAsync(url);
            if (!result.IsSuccessStatusCode) return null;
        
            var data = await result.Content.ReadAsStringAsync();
            var json = JObject.Parse(data);
         
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        
            var dateFromApi = json["results"]
                .Select(token => token["t"].Value<string>())
                .ToArray();
    
            var open = json["results"]
                .Select(token => token["o"].Value<string>())
                .ToArray();
        
            var low = json["results"]
                .Select(token => token["l"].Value<string>())
                .ToArray();
        
            var close= json["results"]
                .Select(token => token["c"].Value<string>())
                .ToArray();
        
            var high= json["results"]
                .Select(token => token["h"].Value<string>())
                .ToArray();
        
            var volume= json["results"]
                .Select(token => token["v"].Value<string>())
                .ToArray();

            Console.WriteLine(url);
            return open.Select((t, i) => new StockChartData()
            {
                Date = dateTime.AddSeconds(long.Parse(dateFromApi[i]) / 1000).ToLocalTime(),
                Open = double.Parse(t),
                Low = double.Parse(low[i]),
                Close = double.Parse(close[i]),
                High = double.Parse(high[i]),
                Volume = double.Parse(volume[i]),
            }).ToArray();
        }
    }
}
