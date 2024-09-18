using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OktaDotNetSix.Controllers
{
    public class AccountController : Controller
    {
        public async Task<ActionResult> Login()
        {            
            var oktaResult = HttpContext.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme).Result;
            if (oktaResult.Succeeded)
            {
                HttpContext.User = new ClaimsPrincipal(oktaResult.Principal.Identity);
                return RedirectToPage("/Privacy");
            }

            return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new[]
            {
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            });
        }
    }
}
