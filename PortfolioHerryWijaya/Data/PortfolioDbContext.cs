using Microsoft.EntityFrameworkCore;
using PortfolioHerryWijaya.Models.Domain;

namespace PortfolioHerryWijaya.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
