using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace project_2;

public class Order
{
    public int OrderId { get; set; }
    public Customer OrderCustomer { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; } = DateTime.Now;

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
         var summary = new StringBuilder();
            summary.AppendLine( $"Order ID: {OrderId} :{OrderDate:yyyy-MM-dd}");
             foreach (var item in Items )
             {
            summary.AppendLine($" {item.OrderedProduct.Name} x {item.Quantity} = ${item.GetItemTotalPrice()}");
         }
             summary.AppendLine( $"{Items.Sum(item => item.GetItemTotalPrice())};");
             return summary.ToString();
         }
    
    
   
}
