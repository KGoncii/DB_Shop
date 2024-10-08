using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; } // Klucz główny
        public string Name { get; set; } // Nazwa produktu
        public string Description { get; set; } // Opis produktu

        [Column(TypeName = "decimal(18,2)")] // Specify precision and scale
        public decimal Price { get; set; }
        public int StockQuantity { get; set; } // Ilość na stanie
        public string Category { get; set; } // Kategoria produktu
        public DateTime CreatedAt { get; set; }

        public Product()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
