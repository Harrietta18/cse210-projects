using System;

class Program
{
    static void Main(string[] args)
    {
        // ---------- Order 1: USA customer ----------
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "KB123", 29.99, 2));
        order1.AddProduct(new Product("Mouse", "MS456", 19.99, 1));

        DisplayOrder(order1);

        // ---------- Order 2: International customer ----------
        Address address2 = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emma Johnson", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Webcam", "WC789", 49.99, 1));
        order2.AddProduct(new Product("USB Hub", "UH012", 24.99, 3));

        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine();
    }
}