using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PortfolioHerryWijaya.Models.Domain.Portfolio3
{
    public class Gacha
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        [ValidateNever]
        public string[] GachaItems { get; set; }
        [ValidateNever]

        public int[] GachaItemPercentages { get; set; }
        public string? ImageUrl {  get; set; }
        public string Description {  get; set; }
    }
}
