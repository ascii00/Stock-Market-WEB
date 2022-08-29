using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockMarket.Shared.Models;
using Microsoft.Extensions.Configuration;
using StockMarket.Server.Services;
using Microsoft.AspNetCore.Authorization;

namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MarketStatusController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStockService _service;

        public MarketStatusController(IConfiguration configuration, IStockService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [Route("Holidays")]
        [HttpGet]
        public async Task<IEnumerable<MarketHoliday>> GetMarketHolidays()
        {
            var apiKey = _configuration["ApiKey"];
            var url = $"https://api.polygon.io/v1/marketstatus/upcoming?apiKey={apiKey}";
            var data = _service.GetJsonFromUrl(url);
            JObject json;
            try
            {
                json = JObject.Parse("{ \"Data\":" + await data + "}");
            }
            catch (Exception)
            {
                return new List<MarketHoliday>();
            }
            var exchange = (json["Data"] ?? throw new InvalidOperationException())
                .Select(token => token["exchange"].Value<string>())
                .ToArray();

            var name = (json["Data"] ?? throw new InvalidOperationException())
                .Select(token => token["name"].Value<string>())
                .ToArray();
        
            var date = (json["Data"] ?? throw new InvalidOperationException())
                .Select(token => token["date"].Value<string>())
                .ToArray();
        
            var status= (json["Data"] ?? throw new InvalidOperationException())
                .Select(token => token["status"].Value<string>())
                .ToArray();
            
            return exchange.Select((_, i) => new MarketHoliday()
            {
                Exchange = exchange[i]?.ToString(),
                HolidayName = name[i]?.ToString(),
                Date = DateTime.Parse(date[i]?.ToString() ?? string.Empty),
                Status = status[i]?.ToString()
            }).ToArray();
        }
        
        [Route("Status")]
        [HttpGet]
        public async Task<MarketStatus> GetMarketStatus()
        {
            var apiKey = _configuration["ApiKey"];
            var url = $"https://api.polygon.io/v1/marketstatus/now?apiKey={apiKey}";
            
            var data = _service.GetJsonFromUrl(url);
            JObject json;
            try
            {
                json = JObject.Parse(await data);
            }
            catch (Exception)
            {
                return new MarketStatus();
            }
            return new MarketStatus
            {
                Market = Convert.ToString(json["market"]),
                Nyse = Convert.ToString(json["exchanges"]?["nyse"]),
                Nasdaq = Convert.ToString(json["exchanges"]?["nasdaq"]),
                Otc = Convert.ToString(json["exchanges"]?["otc"]),
                ServerTime = Convert.ToDateTime(json["serverTime"])
            };
        }
    }
}
