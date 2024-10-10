using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Shop.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string UserId { get; set; }
    }
}
