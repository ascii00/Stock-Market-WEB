using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Shared.Models;
using System.Security.Claims;


namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AddToFavouritesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddToFavouritesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        [HttpGet]
        public async Task<string> Get(StockChartInfo company)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return "";
        }
    }
}