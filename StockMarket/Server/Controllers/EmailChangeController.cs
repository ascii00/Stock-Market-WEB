using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using StockMarket.Server.Models;
using StockMarket.Shared.Models;

namespace StockMarket.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmailChangeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailChangeController(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        
        [HttpPost]
        public async Task<string> Post(ChangeMail mail)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null)
                return "Unable to load user.";

            var email = await _userManager.GetEmailAsync(user);
            
            if (mail.NewMail != email)
            {
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, mail.NewMail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { area="Identity", userId = userId, email = mail.NewMail, code = code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(
                    mail.NewMail,
                    "Confirm your email",
                    $"Please confirm your email by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                
                return "Confirmation link to change email sent. Please check your email.";
            }
            
            return "Your email is unchanged.";
        }
    }
}