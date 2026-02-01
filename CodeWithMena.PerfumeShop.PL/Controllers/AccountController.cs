using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithMena.PerfumeShop.PL.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private const string AdminEmail = "adminkero@gmail.org";
        private const string AdminPassword = "Kero12Ham@d";

        [HttpGet]
        public IActionResult Login([FromQuery] string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, string? returnUrl = null, CancellationToken cancellationToken = default)
        {
            returnUrl ??= Url.Content("~/");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "Email and password are required.");
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            if (!string.Equals(email.Trim(), AdminEmail, StringComparison.OrdinalIgnoreCase) ||
                password != AdminPassword)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email.Trim()),
                new Claim(ClaimTypes.Name, email.Trim())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(CancellationToken cancellationToken = default)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
