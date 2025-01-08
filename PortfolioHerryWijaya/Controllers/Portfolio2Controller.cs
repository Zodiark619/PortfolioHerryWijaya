using Microsoft.AspNetCore.Mvc;
using PortfolioHerryWijaya.Data;
using System.Linq;

namespace PortfolioHerryWijaya.Controllers
{
	public class Portfolio2Controller : Controller
	{
        private readonly PortfolioDbContext portfolioDbContext;

        public Portfolio2Controller(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }
        public IActionResult Index(string? searchQuery,string? sortDirection,string? sortBy,int pageSize, int pageNumber = 1)
		{
          
            var query = portfolioDbContext.DaysGoneWeapons.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(x => x.Name.Contains(searchQuery)
                || x.Source.Contains(searchQuery)
                || x.Type.Contains(searchQuery));
               // || x.Condition==int.TryParse (searchQuery,out int meong));

            }


            var totalRecords = query.Count();
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


            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var isDesc = string.Equals(sortDirection, "Desc", StringComparison.OrdinalIgnoreCase);

                if (string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);

                }
                if (string.Equals(sortBy, "Source", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.Source) : query.OrderBy(x => x.Source);

                }

            }
            //
            var skipResults = (pageNumber - 1) * pageSize;
            query = query.Skip(skipResults).Take(pageSize);
            var weapons=query.ToList();
			return View(weapons);
		}
	}
}
