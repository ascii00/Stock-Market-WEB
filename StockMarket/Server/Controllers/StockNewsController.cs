using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using StockMarket.Server.Services;
using StockMarket.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockNewsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IFavouriteService _favouriteService;
        private readonly IStockService _stockServiceservice;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StockNewsController(
            IConfiguration configuration,
            IFavouriteService favouriteService,
            IStockService stockServiceservice,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _favouriteService = favouriteService;
            _stockServiceservice = stockServiceservice;
        }

        [HttpGet]
        public async Task<IEnumerable<StockNews>> Get()
        {
            var apiKey = _configuration["ApiKey"];

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var allFavourites = await _favouriteService.GetAllFavouritesCompanies(userId);

            List<StockNews> result;

            string url;
            foreach (var favourite in allFavourites)
            {
                // url = $"https://api.polygon.io/v2/reference/news?ticker={favourite.Ticker}&limit=3&apiKey={apiKey}";
                url = $"https://api.polygon.io/v2/reference/news?ticker=TSLA&limit=3&apiKey={apiKey}";
                var data = _stockServiceservice.GetJsonFromUrl(url);
                JObject json;
                try
                {
                    json = JObject.Parse(await data ?? throw new InvalidOperationException());
                }
                catch (Exception)
                {
                    continue;
                }
                
                var title = (json["results"] ?? "")
                    .Select(token => token["title"].Value<string>())
                    .ToArray();

                var publisherName = (json["results"] ?? "")
                    .Select(token => token["publisher"])
                    .Select(token => token["name"].Value<string>())
                    .ToArray();

                var description = (json["results"] ?? "")
                    .Select(token => token["description"].Value<string>())
                    .ToArray();
                
                var articleUrl = (json["results"] ?? "")
                    .Select(token => token["article_url"].Value<string>())
                    .ToArray();

                foreach (var tmp in title)
                {
                    Console.WriteLine(tmp);
                }
                Console.WriteLine();
                
                foreach (var tmp in publisherName)
                {
                    Console.WriteLine(tmp);
                }
                Console.WriteLine();
                
                foreach (var tmp in description)
                {
                    Console.WriteLine(tmp);
                }
                Console.WriteLine();
                
                foreach (var tmp in articleUrl)
                {
                    Console.WriteLine(tmp);
                }
                Console.WriteLine();

                Console.WriteLine(publisherName[0]);
                Console.WriteLine(title.Length);
                Console.WriteLine(publisherName.Length);
                Console.WriteLine(description.Length);
                Console.WriteLine(articleUrl.Length);
            }

            return new List<StockNews>();

        }
    }
}