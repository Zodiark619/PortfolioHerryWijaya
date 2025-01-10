using Microsoft.EntityFrameworkCore;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PortfolioHerryWijaya.Repositories
{
    public class Portfolio2Repository:IPortfolio2Repository
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public Portfolio2Repository(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }

        public IQueryable<DaysGoneWeapon> GetWeaponsWithSearchQuery(string? searchQuery)
        {
            var query = portfolioDbContext.DaysGoneWeapons.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(x => x.Name.Contains(searchQuery)
                 || x.Source.Contains(searchQuery)
                || x.Type.Contains(searchQuery));
                // || x.Condition==int.TryParse (searchQuery,out int meong));
                
            }
            return query;
        }

        public async Task<IEnumerable<DaysGoneWeapon>> GetWeaponsAsync(string? searchQuery, string? sortDirection, string? sortBy, int pageSize=100, int pageNumber = 1)
        {
            var query= GetWeaponsWithSearchQuery(searchQuery);
                if (!query.Any())
                {
                    return new List<DaysGoneWeapon>();
                }
            

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
            var skipResults = (pageNumber - 1) * pageSize;
            query = query.Skip(skipResults).Take(pageSize);
            return await query.ToListAsync();
        }

        public async Task<int> GetWeaponsCountAsync(string? searchQuery)
        {
            
            return await GetWeaponsWithSearchQuery(searchQuery).CountAsync();
          //  return await portfolioDbContext.DaysGoneWeapons.CountAsync();
            
        }
    }
}
