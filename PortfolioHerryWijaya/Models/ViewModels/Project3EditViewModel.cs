using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PortfolioHerryWijaya.Models.ViewModels
{
    public class Project3EditViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
       
        public string[] GachaItems { get; set; }
       

        public int[] GachaItemPercentages { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }


    }
}
