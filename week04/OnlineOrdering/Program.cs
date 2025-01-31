using System;

class Program
{
    static void Main()
    {
        // Create customers with addresses
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Los Angeles", "CA", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("45 Queen St", "Toronto", "ON", "Canada"));

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "H789", 79.99, 1));
        order2.AddProduct(new Product("Keyboard", "K101", 49.99, 1));
        order2.AddProduct(new Product("Monitor", "M202", 199.99, 1));

        // Display order details
        DisplayOrderDetails(order1);
        Console.WriteLine();
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
    }
}
