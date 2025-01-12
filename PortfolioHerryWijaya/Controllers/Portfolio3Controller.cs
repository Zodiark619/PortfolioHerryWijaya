using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models.Domain.Portfolio3;

namespace PortfolioHerryWijaya.Controllers
{
    public class Portfolio3Controller : Controller
    {
        private readonly PortfolioDbContext portfolioDbContext;
        private static int Money = 500;
        private Random random = new Random();
        public Portfolio3Controller(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Money = Money;  
            var gachas=portfolioDbContext.Gachas.ToList();
            return View(gachas);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var gacha = portfolioDbContext.Gachas.Find(id);
            var gachas = portfolioDbContext.Gachas.ToList();
            if (Money < 150)
            {
                ViewBag.Notification = $"Insufficient caliber. Please top-up first!";
                ViewBag.Money = Money;

                return View(gachas);
            }
           
               
                Money -= 150;

            
            int chance1 = gacha.GachaItemPercentages[0];
            int chance2 = gacha.GachaItemPercentages[1];
            int chance3 = gacha.GachaItemPercentages[2];
            int chance4 = gacha.GachaItemPercentages[3];
            int chance5 = gacha.GachaItemPercentages[4];
            int checkpoint1 = chance1;
            int checkpoint2 = checkpoint1 + chance2;
            int checkpoint3 = checkpoint2+chance3;
            int checkpoint4 = checkpoint3+chance4;
            int checkpoint5 = checkpoint4 + chance5;
            int randomResult=random.Next(1,101);
            int counter;
            if (randomResult <= checkpoint1)
            {
                counter = 0;
            }
            else if (randomResult <= checkpoint2)
            {
                counter = 1;

            }
            else if (randomResult <= checkpoint3)
            {
                counter = 2;

            }
            else if (randomResult <= checkpoint4)
            {
                counter = 3;

            }
            else 
            {
                counter = 4;

            }
            ViewBag.Notification = $"You get {gacha.GachaItems[counter]}";
            ViewBag.Money = Money;

            return View(gachas);
        }
    }
}
