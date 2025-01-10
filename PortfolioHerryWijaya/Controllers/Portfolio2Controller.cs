using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Repositories;
using System.Linq;

namespace PortfolioHerryWijaya.Controllers
{
	public class Portfolio2Controller : Controller
	{
        private readonly IPortfolio2Repository portfolio2Repository;

        public Portfolio2Controller(IPortfolio2Repository portfolio2Repository)
        {
            this.portfolio2Repository = portfolio2Repository;
        }
        public async Task<IActionResult> Index(string? searchQuery,string? sortDirection,string? sortBy,int pageSize=3, int pageNumber = 1)
		{
         
            var totalRecords=await portfolio2Repository.GetWeaponsCountAsync(searchQuery);

          //  var totalRecords = await portfolio2Repository.GetWeaponsCountAsync();
            pageSize = 3;
            var totalPages = Math.Ceiling((decimal)totalRecords / pageSize);
           
            if (pageNumber < 1)
            {
                pageNumber++;
            }
            if (pageNumber > totalPages)
            {
                pageNumber--;
            }

            ViewBag.SearchQuery = searchQuery;
            ViewBag.SortDirection = sortDirection;
            ViewBag.SortBy = sortBy;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
            ViewBag.PageNumber = pageNumber;


            
            var weapons=await portfolio2Repository.GetWeaponsAsync(searchQuery,
                sortDirection,
                sortBy,
                pageSize,
                pageNumber
                );
			return View(weapons);
		}
	}
}
