using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using StockMarket.Server.Services;
using StockMarket.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockInfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStockService _service;

        public StockInfoController(IConfiguration configuration, IStockService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [HttpGet("{ticker}")]
        public async Task<StockChartInfo> Get(string ticker)
        {
            var apiKey = _configuration["ApiKey"];
            var url = $"https://api.polygon.io/v3/reference/tickers/{ticker}?apiKey={apiKey}";

            var data = _service.GetJsonFromUrl(url);
            JObject json;
            try
            {
                json = JObject.Parse(await data);
            }
            catch (Exception)
            {
                return new StockChartInfo();
            }

            return new StockChartInfo
            {
                Ticker = Convert.ToString(json["results"]?["ticker"]),
                Name = Convert.ToString(json["results"]?["name"]),
                Description = Convert.ToString(json["results"]?["description"]),
                HomePage = Convert.ToString(json["results"]?["homepage_url"])?.Replace("https://www.", ""),  
                LogoUrl = Convert.ToString(json["results"]?["branding"]?["logo_url"]) + "?apiKey=" + apiKey, 
                Address = Convert.ToString(json["results"]?["address"]?["address1"]) + " " +
                          Convert.ToString(json["results"]?["address"]?["city"]) + " " +
                          Convert.ToString(json["results"]?["address"]?["state"]) + " " +
                          Convert.ToString(json["results"]?["address"]?["postal_code"]),
                City = Convert.ToString(json["results"]?["address"]?["city"])
            };
        }
    }
}