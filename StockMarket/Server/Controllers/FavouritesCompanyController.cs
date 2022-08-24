using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Shared.Models;
using System.Security.Claims;
using StockMarket.Server.Services;


namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavouritesCompanyController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFavouriteService _service;

        public FavouritesCompanyController(
            IHttpContextAccessor httpContextAccessor,
            IFavouriteService service)
        {
            _httpContextAccessor = httpContextAccessor;
            _service = service;
        }
        
        [HttpPost]
        [Route("Add")]
        public async Task<string> Add(StockChartInfo company)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _service.AddCompanyToFavourite(new FavouriteCompany()
            {
                UserId = userId,
                Ticker = company.Ticker,
                CompanyName = company.Name,
                City = company.City,
                AddingDate = DateTime.Now
            });
        }
        
        [HttpPost]
        [Route("Remove")]
        public async Task<string> Remove(StockChartInfo company)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _service.RemoveCompanyFromFavourites(new FavouriteCompany()
            {
                UserId = userId,
                Ticker = company.Ticker,
            });
        }
        
        [HttpPost]
        [Route("Check")]
        public async Task<bool> Check(StockChartInfo company)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _service.CheckCompanyOnFavourite(new FavouriteCompany()
            {
                UserId = userId,
                Ticker = company.Ticker,
            });
        }

        [HttpGet]
        public async Task<IEnumerable<FavouriteCompany>> GetAll(string ticker)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _service.GetAllFavouritesCompanies(userId);
        }
    }
}