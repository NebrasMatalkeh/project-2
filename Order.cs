using System;

namespace project_2;

public class Order
{
    public int OrderId { get; set; }
    public Customer OrderCustomer { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }

    public void AddItemToOrder(Product product, int quantity)
    {
        var orderItem = new OrderItem { OrderedProduct = product, Quantity = quantity };
        Items.Add(orderItem);
    }

    public decimal GetOrderTotalPrice()
    {
        return Items.Sum(item => item.GetItemTotalPrice());
    }

    public string GetOrderSummary()
    {
        var summary = $"Order ID: {OrderId}";
        foreach (var item in Items)
        {
            summary += $"{item.OrderedProduct.Name} x {item.Quantity} = ${item.GetItemTotalPrice()}";
        }
        summary += $"Total: ${GetOrderTotalPrice()}";
        return summary;
    }
    
   
}
