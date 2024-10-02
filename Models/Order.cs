using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class Order
{
    public int OrderId { get; set; } // Klucz główny
    public DateTime OrderDate { get; set; } // Data zamówienia
    public decimal TotalAmount { get; set; } // Całkowita kwota zamówienia

    // Powiązanie zamówienia z użytkownikiem, który jest zarządzany przez ASP.NET Identity
    public string UserId { get; set; } // Identyfikator użytkownika z tabeli Identity
    public IdentityUser User { get; set; } // Użytkownik ASP.NET Identity

    // Pozycje zamówienia - proste połączenie z produktami
    public ICollection<OrderItem> OrderItems { get; set; }

    // Status zamówienia (np. "Przyjęte", "W trakcie realizacji", "Zrealizowane")
    public string Status { get; set; }

    // Pola śledzenia czasu
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
