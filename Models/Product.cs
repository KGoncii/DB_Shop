namespace DB_Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; } // Klucz główny
        public string Name { get; set; } // Nazwa produktu
        public string Description { get; set; } // Opis produktu
        public decimal Price { get; set; } // Cena
        public int StockQuantity { get; set; } // Ilość na stanie
        public string Category { get; set; } // Kategoria produktu
        public DateTime CreatedAt { get; set; }

        public Product()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
