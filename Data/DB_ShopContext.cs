using DB_Shop.Models;
using Microsoft.EntityFrameworkCore;

public class DB_ShopContext : DbContext
{
    public DB_ShopContext(DbContextOptions<DB_ShopContext> options)
        : base(options)
    {
    }

    // DbSets for your shop models
    public DbSet<Product> Product { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
}
