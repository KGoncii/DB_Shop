using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DB_Shop.Models;

namespace DB_Shop.Data
{
    public class DB_ShopContext : DbContext
    {
        public DB_ShopContext (DbContextOptions<DB_ShopContext> options)
            : base(options)
        {
        }

        public DbSet<DB_Shop.Models.Product> Product { get; set; } = default!;
    }
}
