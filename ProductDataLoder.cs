using System;
using System.Globalization;

namespace project_2;

public class ProductDataLoder : IDataLoder
{
    public List<Product> Products { get; private set; } = new List<Product>();

    public void LoadData(string filePath)
    {
        var lines = File.ReadAllLines(filePath);


        foreach (var line in lines)
        {
            var parts = line.Split(':');
            Console.WriteLine(line);

            try
            {
                var product = new Product

                {

                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Price = decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                    StockQuantity = int.Parse(parts[3])
                };
                Products.Add(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
    }
}
