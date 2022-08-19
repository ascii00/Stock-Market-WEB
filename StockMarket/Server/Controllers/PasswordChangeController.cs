using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StockMarket.Server.Models;
using StockMarket.Shared.Models;

namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordChangeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PasswordChangeController(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<string> Post(ChangePassword passwords)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null)
                return "Unable to load user.";

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, passwords.OldPassword, passwords.NewPassword);
            if (!changePasswordResult.Succeeded)
                return "The entered password is incorrect.";

            await _signInManager.RefreshSignInAsync(user);
            
            return "Your password has been changed.";
        }
    }
}