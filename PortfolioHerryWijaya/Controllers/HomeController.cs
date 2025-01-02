using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models;
using System.Diagnostics;

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

      
    }
}
