using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockMarket.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Globalization;
using StockMarket.Server.Services;
using Microsoft.AspNetCore.Authorization;

namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockChartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStockService _service;

        public StockChartController(IConfiguration configuration, IStockService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [HttpGet("{ticker}")]
        public async Task<IEnumerable<StockChartData>> Get(string ticker)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            var dateYearBefore = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
        
            var apiKey = _configuration["ApiKey"];
            var url = $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/{dateYearBefore}/{dateNow}?adjusted=true&sort=asc&apiKey={apiKey}";

            var data = _service.GetJsonFromUrl(url);
            
            JObject json;
            try
            {
                json = JObject.Parse(await data);
            }
            catch (Exception)
            {
                return new List<StockChartData>();
            }

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        
            var dateFromApi = (json["results"] ?? throw new InvalidOperationException())
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
            
            return open.Select((t, i) => new StockChartData()
            {
                Date = dateTime.AddSeconds(long.Parse(dateFromApi[i]) / 1000).ToLocalTime(),
                Open = double.Parse(t),
                Low = double.Parse(low[i] ?? throw new InvalidOperationException()),
                Close = double.Parse(close[i] ?? throw new InvalidOperationException()),
                High = double.Parse(high[i] ?? throw new InvalidOperationException()),
                Volume = double.Parse(volume[i] ?? throw new InvalidOperationException()),
            }).ToArray();
        }
    }
}
