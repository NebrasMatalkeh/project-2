using System;

namespace project_2;

public class OrderItem
{
    public Product OrderedProduct { get; set; }
    public int Quantity { get; set; }

    public decimal GetItemTotalPrice()
    {
        return OrderedProduct.Price * Quantity;
    }
}

