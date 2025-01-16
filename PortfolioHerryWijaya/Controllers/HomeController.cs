using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models;
using System.Diagnostics;
using System.Security.Claims;
using PortfolioHerryWijaya.Models.ViewModels;

namespace PortfolioHerryWijaya.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public HomeController(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }

        public IActionResult Index()
        {
            var portfolios=portfolioDbContext.Portfolios.ToList();
            return View(portfolios);
        }




		public IActionResult Login()
		{

			return View();
		}




		[HttpPost]
		public IActionResult Login(LoginViewModel user)
		{
			//------------
			if (!ModelState.IsValid)
			{
				return View(user);
			}
			//------------
			var foundUser = portfolioDbContext.Users.FirstOrDefault(x => x.Email == user.Email.Trim() && x.Password == user.Password.Trim());
			//-----
			if (foundUser == null)
			{
				ModelState.AddModelError("Email", "User not exist");
				return View(user);
			}
			//------------
			// Create claims for the authenticated user
			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.NameIdentifier, foundUser.Id.ToString()));
			claims.Add(new Claim(ClaimTypes.Name, foundUser.FullName));
			claims.Add(new Claim(ClaimTypes.Email, foundUser.Email));
			//------------
			if (foundUser.IsAdmin == true)
			{
				claims.Add(new Claim(ClaimTypes.Role, "admin"));
			}
			else
			{
				claims.Add(new Claim(ClaimTypes.Role, "user"));
			}
			//------------
			// Create an identity based on the claims
			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			//------------
			// Create a principal based on the identity
			var principal = new ClaimsPrincipal(identity);
			//------------
			// Sign in the user with the created principal
			HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
			//------------
			return RedirectToAction("Index","Home");
		}
		[Authorize]
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Home");
		}

	}
}
