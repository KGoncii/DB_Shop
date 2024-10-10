using DB_Shop.Data;
using DB_Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DB_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly DB_ShopContext _context;
        public CartController(DB_ShopContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItems = _context.Cart
                .Where(c => c.UserId == userId)
                .Include(c => c.Product) 
                .ToList();

            return View(cartItems);
        }

        [Authorize]
        public IActionResult AddToCart(int id)
        {
            var productToAdd = _context.Product.Find(id);
            if (productToAdd == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var existingCartItem = _context.Cart
                .FirstOrDefault(c => c.ProductId == id && c.UserId == userId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                var newCartItem = new Cart
                {
                    ProductId = productToAdd.ProductId,
                    UserId = userId,
                    Quantity = 1
                };
                _context.Cart.Add(newCartItem);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}
