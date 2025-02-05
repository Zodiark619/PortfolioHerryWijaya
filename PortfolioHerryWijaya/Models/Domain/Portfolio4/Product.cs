namespace PortfolioHerryWijaya.Models.Domain.Portfolio4
{
	public class Product
	{


		public int Id { get; set; }
		public string Title { get; set; }

		public int Caliber { get; set; }  //Price
		public int Discount { get; set; } = 0;
	}
}
