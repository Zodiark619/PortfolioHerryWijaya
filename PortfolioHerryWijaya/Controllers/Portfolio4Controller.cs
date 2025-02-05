using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models.ViewModels.Project4;

namespace PortfolioHerryWijaya.Controllers
{
    public class Portfolio4Controller : Controller
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public Portfolio4Controller(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }
        public List<CartViewModel> GetCartItems()
        {
            List<CartViewModel> cartList = new List<CartViewModel>();

            var prevCartItemsString = Request.Cookies["Cart"];

            // If it's not null, it means the cart is not empty, so we need to convert it to a list of view models; 
            // otherwise, we return an empty cart list.
            if (!string.IsNullOrEmpty(prevCartItemsString))
            {
                cartList = JsonConvert.DeserializeObject<List<CartViewModel>>(prevCartItemsString);
            }

            return cartList;
        }

        public List<ProductCartViewModel> GetProductsInCart()
        {
            var cartItems = GetCartItems();

            if (!cartItems.Any())
            {
                return null;
            }

            var cartItemProductIds = cartItems.Select(x => x.ProductId).ToList();
            // Load products into memory
            var products = portfolioDbContext.Products
                .Where(p => cartItemProductIds.Contains(p.Id))
                .ToList();

            // Create the ProductCartViewModel list

            List<ProductCartViewModel> result = new List<ProductCartViewModel>();
            foreach (var item in products)
            {
                var newItem = new ProductCartViewModel
                {
                    Id = item.Id,

                    Caliber = item.Caliber - item.Discount,
                    Title = item.Title,
                    Count = cartItems.Single(x => x.ProductId == item.Id).Count,
                    RowSumPrice = (item.Caliber - item.Discount ) * cartItems.Single(x => x.ProductId == item.Id).Count,
                };

                result.Add(newItem);
            }

            return result;
        }

		public IActionResult SmallCart()
		{
			var result = GetProductsInCart();

			return PartialView(result);
		}
		public IActionResult UpdateCart([FromBody] CartViewModel request)
		{

			var product = portfolioDbContext.Products.FirstOrDefault(x => x.Id == request.ProductId);
			if (product == null)
			{
				return NotFound();
			}
			// Retrieve the list of products in the cart using the dedicated function
			var cartItems = GetCartItems();

			var foundProductInCart = cartItems.FirstOrDefault(x => x.ProductId == request.ProductId);

			// If the product is found, it means it is in the cart, and the user intends to change the quantity
			if (foundProductInCart == null)
			{
				var newCartItem = new CartViewModel() { };
				newCartItem.ProductId = request.ProductId;
				newCartItem.Count = request.Count;

				cartItems.Add(newCartItem);
			}
			else
			{
				// If greater than zero, it means the user wants to update the quantity; otherwise, it will be removed from the cart.
				if (request.Count > 0)
				{
					foundProductInCart.Count = request.Count;
				}
				else
				{
					cartItems.Remove(foundProductInCart);
				}
			}

			var json = JsonConvert.SerializeObject(cartItems);

			CookieOptions option = new CookieOptions();
			option.Expires = DateTime.Now.AddDays(7);
			Response.Cookies.Append("Cart", json, option);

			var result = cartItems.Sum(x => x.Count);

			return Ok(result);
		}
		public IActionResult ClearCart()
		{
			Response.Cookies.Delete("Cart");
			return Redirect("/");
		}
		public IActionResult Index()
        {
            var products=portfolioDbContext.Products.ToList();
            return View(products);
        }
    }
}
