using System;

namespace project_2;

public class CustomerDataLoder : IDataLoder
{
    public List<Customer> Customers { get; private set; } = new List<Customer>();

    public void LoadData(string filePath)

    {

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(':');

            var customer = new Customer
            {
                Id = int.Parse(parts[0]),
                Name = parts[1]
            };
            Customers.Add(customer);
        }
    }
}
