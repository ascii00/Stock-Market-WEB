using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StockMarket.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TickersController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Ticker>> Get()
        {
            string data;
            using (var reader = new StreamReader("Resources/tickersJson.json"))
            {
                data = await reader.ReadToEndAsync();
            }
            
            var json = JObject.Parse(data);
            
            var names = (json["results"] ?? throw new InvalidOperationException())
                .Select(token => token["Name"].Value<string>())
                .ToArray();
            
            for(var i=0; i<names.Length; i++)
            {
                if (names[i]!.Length > 19)
                    names[i] = names[i][..16] + "...";
            }
            
            var symbols = json["results"]
                .Select(token => token["Symbol"].Value<string>())
                .ToArray();
            
            return symbols
                .Select((t, i) => new Ticker() { Name = names[i], TickerSymbol = t })
                .ToList();
        }
    }
}