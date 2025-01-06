using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Data;

namespace PortfolioHerryWijaya.Controllers
{
	public class DapperController : Controller
	{
        private readonly PortfolioDbContext portfolioDbContext;

        public DapperController(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }
        public IActionResult Index()
		{
            var weapons=portfolioDbContext.DaysGoneWeapons.ToList();
			return View(weapons);
		}
	}
}
