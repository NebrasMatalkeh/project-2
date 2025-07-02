using System;

namespace project_2;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public void DecreaseStock(int amount)
    {
        if (StockQuantity  < amount)
            throw new InvalidOperationException("Not enough stock.");
        StockQuantity -= amount;
    }

    public void IncreaseStock(int amount)
    {
        StockQuantity += amount;
    }

    public string GetProductDetails()
    {
        return $"{Id}: {Name} - ${Price} (Stock: {StockQuantity})";
    }
}
