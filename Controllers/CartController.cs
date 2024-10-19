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
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var cartItems = await _context.Cart
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync();

            ViewBag.TotalPrice = cartItems.Sum(item => item.Quantity * item.Product.Price);

            return View(cartItems);
        }

        [Authorize]
        public IActionResult AddToCart(int id)
        {
            var productToAdd = _context.Product.Find(id);
            var productIdQuantity = _context.Product.Where(c => c.ProductId == id).Select(c => c.StockQuantity).FirstOrDefault();
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

            if (productIdQuantity != 0)
            {
                if (existingCartItem != null && existingCartItem.Quantity + 1 <= productIdQuantity)
                {
                    existingCartItem.Quantity++;
                }
                else if (existingCartItem == null || existingCartItem.Quantity + 1 <= productIdQuantity)
                {
                    var newCartItem = new Cart
                    {
                        ProductId = productToAdd.ProductId,
                        UserId = userId,
                        Quantity = 1
                    };
                    _context.Cart.Add(newCartItem);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult IncreaseQuantity(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cartItem = _context.Cart.FirstOrDefault(c => c.CartId == id && c.UserId == userId);

            if (cartItem != null)
            {
                var product = _context.Product.Find(cartItem.ProductId);
                if (product != null && cartItem.Quantity < product.StockQuantity)
                {
                    cartItem.Quantity++;
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult DecreaseQuantity(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cartItem = _context.Cart.FirstOrDefault(c => c.CartId == id && c.UserId == userId);

            if (cartItem != null && cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public IActionResult RemoveFromCart(int id)
        {
            var cartItemToRemove = _context.Cart.Find(id);
            if (cartItemToRemove == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cartItemToRemove);
            _context.SaveChanges();

            return RedirectToAction("Index");
        } 

        public IActionResult Order()
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
    }
}
