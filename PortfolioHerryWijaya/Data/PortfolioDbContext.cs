using Microsoft.EntityFrameworkCore;
using PortfolioHerryWijaya.Models.Domain;
using PortfolioHerryWijaya.Models.Domain.Portfolio3;

namespace PortfolioHerryWijaya.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions options) : base(options)
        {
        }
        //project1
        public DbSet<Portfolio> Portfolios { get; set; }
        //project2
        public DbSet<DaysGoneWeapon> DaysGoneWeapons { get; set; }
        //project3
        public DbSet<Gacha> Gachas { get; set; }
        public DbSet<GachaItem> GachaItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaysGoneWeapon>().HasData(
                new DaysGoneWeapon
                {
                    Id = 1,
                    Name = "SAF",
                    Type = "Assault Rifle",
                    Condition = 1,
                    Source = "Pick Up"
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



            modelBuilder.Entity<GachaItem>().HasData(
                new GachaItem
                {
                    Id = 1,
                    Name = "1 Million Gold"
                },
                new GachaItem
                {
                    Id = 2,
                    Name = "1 Million Kuiper"
                },
                new GachaItem
                {
                    Id = 3,
                    Name = "Ultimate Freyna Surprise Box"
                },
                new GachaItem
                {
                    Id = 4,
                    Name = "Crystallization Catalyst"
                },
                new GachaItem
                {
                    Id = 5,
                    Name = "Ultimate Valby Surprise Box"
                },
                new GachaItem
                {
                    Id = 6,
                    Name = "Energy Activator"
                },
                new GachaItem
                {
                    Id = 7,
                    Name = "Ultimate Weapon Surprise Box"
                },
                new GachaItem
                {
                    Id = 8,
                    Name = "Ultimate Reactor Surprise Box"
                }
                );


            modelBuilder.Entity<Gacha>().HasData(
                new Gacha
                {
                    Id = 1,
                    Name = "Ultimate Freyna Pick Up Gacha",
                    GachaItems = new string[]
                    {

                    "1 Million Gold",
                    "1 Million Kuiper",
                        "Ultimate Freyna Surprise Box",
                        "Crystallization Catalyst",
                        "Energy Activator"


                    },
                    GachaItemPercentages = new int[]
                    {
                        30,30,10,15,15
                    },
                    ImageUrl="ultimatefreyna.png",
                    Description="10% chance to get Ultimate Freyna Surprise Box " +
                    "(Contains unique cosmetics, taunts, skins, and animations for Ultimate Freyna)"
                },
                new Gacha
                {
                    Id = 2,
                    Name = "Ultimate Ines Pick Up Gacha",
                    GachaItems = new string[]
                    {

                    "Ultimate Weapon Surprise Box",
                    "Ultimate Reactor Surprise Box",
                        "Ines Surprise Box",
                        "Crystallization Catalyst",
                        "Energy Activator"


                    },
                    GachaItemPercentages = new int[]
                    {
                        20,20,20,20,20
                    },
                    ImageUrl = "ines.png",
                    Description = "20% chance to get Ines Surprise Box " +
                    "(Contains Ines fragments and 1% chance of obtaining Ines's unique skin)"

                }
                );

        }
    }
}
