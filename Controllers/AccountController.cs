//using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authentication.OpenIdConnect;
//using static System.Net.WebRequestMethods;

namespace OpenID.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "https://localhost:7201/Account" },
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        
        public IActionResult Register()
        {
            return View();
        }
    }
}
