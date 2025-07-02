using System;

namespace project_2;

public class Customer
{
public int Id { get; set; }
    public string Name { get; set; }
    public List<Order> OrderHistory { get; set; } = new List<Order>();

    public void AddOrderToHistory(Order order)
    {
        OrderHistory.Add(order);
    }

    public string GetCustomerDetails()
    {
        return $"{Id}: {Name}";
    }
}
