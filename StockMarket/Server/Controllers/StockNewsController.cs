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
        private readonly IStockService _stockService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StockNewsController(
            IConfiguration configuration,
            IFavouriteService favouriteService,
            IStockService stockService,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _favouriteService = favouriteService;
            _stockService = stockService;
        }

        [HttpGet("{ticker}")]
        public async Task<IEnumerable<StockNews>> Get(string ticker)
        {
            var apiKey = _configuration["ApiKey"];

            var result = new List<StockNews>();

            var url = $"https://api.polygon.io/v2/reference/news?ticker={ticker}&limit=15&apiKey={apiKey}";
            var data = _stockService.GetJsonFromUrl(url);
            JObject json;
            try
            {
                json = JObject.Parse(await data ?? throw new InvalidOperationException());
            }
            catch (Exception)
            {
                return result;
            }

            var title = (json["results"] ?? "")
                .Select(token => token["title"])
                .ToArray();

            var publisherName = (json["results"] ?? "")
                .Select(token => token["publisher"])
                .Select(token => token["name"])
                .ToArray();

            var description = (json["results"] ?? "")
                .Select(token => token["description"])
                .ToArray();
                
            var articleUrl = (json["results"] ?? "")
                .Select(token => token["article_url"])
                .ToArray();
                
            var publishedUtc = (json["results"] ?? "")
                .Select(token => token["published_utc"])
                .ToArray();

            for (var i = 0; i < title.Length; i++)
            {
                title[i] ??= "";
                publisherName[i] ??= "";
                description[i] ??= "";
                articleUrl[i] ??= "";

                result.Add(new StockNews()
                {
                    Title = title[i].ToString(),
                    PublisherName = publisherName[i].ToString(),
                    Description = description[i].ToString(),
                    ArticleUrl = articleUrl[i].ToString(),
                    PublishedDate = Convert.ToDateTime(publishedUtc[i])
                });
            }
            Console.WriteLine(result.Count);
            return result;
        }
    }
}