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
        public DbSet<DaysGoneWeapon> DaysGoneWeapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaysGoneWeapon>().HasData(
                new DaysGoneWeapon
                {
                    Id=1,
                    Name="SAF",
                    Type="Assault Rifle",
                    Condition=1,
                    Source="Pick Up"
                },

                 new DaysGoneWeapon
                 {
                     Id = 2,
                     Name = "MWS",
                     Type = "Assault Rifle",
                     Condition = 3,
                     Source = "Hot Springs"
                 },

                  new DaysGoneWeapon
                  {
                      Id = 3,
                      Name = "US556",
                      Type = "Assault Rifle",
                      Condition = 3,
                      Source = "Hot Springs"
                  },

                   new DaysGoneWeapon
                   {
                       Id = 4,
                       Name = "M7",
                       Type = "Rifle",
                       Condition = 1,
                       Source = "Pick Up"
                   },

                    new DaysGoneWeapon
                    {
                        Id = 5,
                        Name = ".22 Repeater",
                        Type = "Rifle",
                        Condition = 2,
                        Source = "Hot Springs"
                    },

                     new DaysGoneWeapon
                     {
                         Id = 6,
                         Name = "Liberator",
                         Type = "Shotgun",
                         Condition = 5,
                         Source = "Iron Mike's"
                     },

                      new DaysGoneWeapon
                      {
                          Id = 7,
                          Name = "PPSH-41",
                          Type = "SMG",
                          Condition = 4,
                          Source = "Wizard Island"
                      },
                       new DaysGoneWeapon
                       {
                           Id = 8,
                           Name = "SWAT-10",
                           Type = "SMG",
                           Condition = 3,
                           Source = "Iron Mike's"
                       }
                );
        }
    }
}
