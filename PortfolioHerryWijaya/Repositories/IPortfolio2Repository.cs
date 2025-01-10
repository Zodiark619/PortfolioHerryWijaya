using PortfolioHerryWijaya.Models.Domain;

namespace PortfolioHerryWijaya.Repositories
{
    public interface IPortfolio2Repository
    {


        Task<IEnumerable<DaysGoneWeapon>> GetWeaponsAsync(string? searchQuery, 
            string? sortDirection, 
            string? sortBy, 
            int pageSize=100, 
            int pageNumber = 1);

        Task<int> GetWeaponsCountAsync(string? searchQuery);
      //  Task<int> GetWeaponsCountAsync();

        IQueryable<DaysGoneWeapon> GetWeaponsWithSearchQuery(string? searchQuery);
    }
}
