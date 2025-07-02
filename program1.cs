using System;

namespace project_2;

public class program1
{

    private static List<Product> products = new List<Product>();
    private static List<Customer> customers = new List<Customer>();
    private static Customer currentCustomer;
    private static List<OrderItem> currentShoppingCart = new List<OrderItem>();
    public static ProductDataLoder productLoader = new ProductDataLoder();
    public static CustomerDataLoder customerLoader = new CustomerDataLoder();

    public static void Main(string[] args)
    {



        LoadData();
        Login();
        MainMenu();


    }

    public static void SaveOrderToFile(Order order)
    {
        try
        {
            string filePath = @"/Users/air/Desktop/project 2/statics/product.txt";
            var existingData = File.Exists(filePath)? File.ReadAllLines(filePath).ToList() : new List<string>();
            

                foreach (var item in currentShoppingCart)
                {
                    string newLine = $" {item.OrderedProduct.Id}:{item.OrderedProduct.Name}:{item.OrderedProduct.Price}:{item.Quantity}";

                    var existingLine = existingData.FirstOrDefault(line => line.StartsWith($"{item.OrderedProduct.Id}:"));

                if (existingLine != null)
                {

                    existingData[existingData.IndexOf(existingLine)] = newLine;
                }
                else
                    break;
                }

            File.WriteAllLines(filePath, existingData);
            Console.WriteLine("Order saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save order: {ex.Message}");
        }
    }


    public static void LoadData()
    {
        var productLoader = new ProductDataLoder();
        productLoader.LoadData(@"/Users/air/Desktop/project 2/statics/product.txt");
        products = productLoader.Products;

        var customerLoader = new CustomerDataLoder();
        customerLoader.LoadData(@"/Users/air/Desktop/project 2/statics/customer.txt");
        customers = customerLoader.Customers;
    }

    public static void Login()
    {
        Console.WriteLine("Available Customers:");
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.GetCustomerDetails());
        }

        Console.Write("Enter Customer ID to log in: ");
        int customerId = int.Parse(Console.ReadLine());
        currentCustomer = customers.FirstOrDefault(p => p.Id == customerId);
    }

    private static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine($"--- Welcome, {currentCustomer.Name}! ---");
            Console.WriteLine("1. Browse All Products");
            Console.WriteLine("2. Add Product to Shopping Cart");
            Console.WriteLine("3. View Shopping Cart");
            Console.WriteLine("4. View My Order History");
            Console.WriteLine("5. Checkout (Place Order)");
            Console.WriteLine("6. Logout");
            Console.WriteLine("-----------------------------------");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BrowseProducts();
                    break;
                case "2":
                    AddProductToCart();
                    break;
                case "3":
                    ViewShoppingCart();
                    break;
                case "4":
                    ViewOrderHistory();
                    break;
                case "5":
                    Checkout();
                    break;
                case "6":
                    Logout();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void Logout()
    {

        Console.WriteLine($"Logged out successfully.{currentCustomer.Name}");
        currentCustomer = null;
    }


    private static void ViewOrderHistory()
    {
        foreach (var item in currentShoppingCart)
        {
            Console.WriteLine($"{item.OrderedProduct.Name} x {item.Quantity} = ${item.GetItemTotalPrice()}");
        }
        Console.WriteLine($"Total: ${currentShoppingCart.Sum(item => item.GetItemTotalPrice())}");
    }


    private static void Checkout()
    {

        var order = new Order { OrderId = new Random().Next(7, 50), OrderCustomer = currentCustomer };
        foreach (var item in currentShoppingCart)
        {
            item.OrderedProduct.DecreaseStock(item.Quantity);
            order.AddItemToOrder(item.OrderedProduct, item.Quantity);
        }
        currentCustomer.AddOrderToHistory(order);
        Console.WriteLine(order.GetOrderSummary());
        SaveOrderToFile(order);

        currentShoppingCart.Clear();
    }

    private static void BrowseProducts()
    {
        foreach (var product in products)
        {
            Console.WriteLine(product.GetProductDetails());
        }
    }

    private static void AddProductToCart()
    {
        Console.Write("Enter Product ID: ");
        int productId = int.Parse(Console.ReadLine());
        var product = products.FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write("Enter Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        if (quantity > product.StockQuantity)
        {
            Console.WriteLine("Not enough stock available.");
            return;
        }

        currentShoppingCart.Add(new OrderItem { OrderedProduct = product, Quantity = quantity });
        Console.WriteLine("Product added to cart.");
    }

    private static void ViewShoppingCart()
    {
        foreach (var item in currentShoppingCart)
        {
            Console.WriteLine($"{item.OrderedProduct.Name} x {item.Quantity} = ${item.GetItemTotalPrice()}");
        }
        Console.WriteLine($"Total: ${currentShoppingCart.Sum(item => item.GetItemTotalPrice())}");
    }


}















