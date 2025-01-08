using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Models.ViewModels;

namespace PortfolioHerryWijaya.Controllers
{
    public class Portfolio1Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.FV = 0;

            return View();
        }

        //public IActionResult Portfolio1()
        //{
        //    ViewBag.FV = 0;
        //    return View();
        //}

        [HttpPost]
        public IActionResult Index(Portfolio1 model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FV = model.CalculateFutureValue();
            }
            else
            {
                ViewBag.FV = 0;
            }
            return View(model);
        }
    }
}
