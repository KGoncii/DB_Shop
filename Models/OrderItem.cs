using DB_Shop.Models;

public class OrderItem
{
    public int OrderItemId { get; set; } // Klucz główny
    public int Quantity { get; set; } // Ilość zamówionego produktu
    public decimal UnitPrice { get; set; } // Cena jednostkowa w momencie zamówienia

    // Relacja wiele do jednego (pozycja zamówienia dotyczy jednego zamówienia)
    public int OrderId { get; set; }
    public Order Order { get; set; }

    // Relacja wiele do jednego (pozycja zamówienia dotyczy jednego produktu)
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
