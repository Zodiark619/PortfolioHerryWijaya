using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioHerryWijaya2.Model
{
    public class Gacha
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int[] Percentage { get; set; }
        public string[] Items { get; set; }



        public List<Gacha> SeedData()
        {
            var meong = new List<Gacha>()
            {
                new Gacha
                {
                    Id=1,
                    Name="Amorpheus 1",
                    Percentage=new int[]{ 20,20,20,20,20},
                    Items=new string[]
                    {
                        "Crystallization Catalyst",
                        "1.000.000 Gold",
                        "1.000.000 Kuiper",
                        "Random Rare Weapon",
                        "Random Rare Reactor"
                    }

                },
                new Gacha
                {
                    Id=2,
                    Name="Amorpheus 2",
                    Percentage=new int[]{ 10,20,30,20,20},
                    Items=new string[]
                    {
                        "Crystallization Catalyst",
                        "10.000.000 Gold",
                        "10.000.000 Kuiper",
                        "Random Rare Weapon",
                        "Random Rare Reactor"
                    }

                },

            };
            

            return meong;
        }
    }

   


}
