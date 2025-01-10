using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Data;

namespace PortfolioHerryWijaya.Controllers
{
    public class Portfolio3Controller : Controller
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public Portfolio3Controller(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }
        public IActionResult Index()
        {
            var gachas=portfolioDbContext.Gachas.ToList();
            return View(gachas);
        }
    }
}
