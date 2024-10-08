using DB_Shop.Data;
using DB_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB_Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly DB_ShopContext _context;
        private List<ShoppingCartItem> _cartItems;

        public ShoppingCartController(DB_ShopContext context)
        {
            _context = context;
            _cartItems = new List<ShoppingCartItem>();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            var productToAdd = _context.Product.Find(id);

            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingCartItem = cartItems.FirstOrDefault(x => x.Product.ProductId == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem
                {
                    Product = productToAdd,
                    Quantity = 1
                });
            }

            HttpContext.Session.Set("Cart", cartItems);

            return RedirectToAction("ViewCart");
        }


        public IActionResult ViewCart()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var cartViewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(x => (x.Product.Price * x.Quantity))
            };
            return View(cartViewModel);
        }
    }
}
