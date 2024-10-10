using Microsoft.EntityFrameworkCore;
using DB_Shop.Models;

namespace DB_Shop.Data
{
    public class DB_ShopContext : DbContext
    {
        public DB_ShopContext(DbContextOptions<DB_ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;

        // Dodaj nowy DbSet dla Cart
        public DbSet<Cart> Cart { get; set; }
    }
}
