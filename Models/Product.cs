namespace DB_Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }

        public Product()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
