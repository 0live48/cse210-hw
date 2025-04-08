using System;

class Program
{
    static void Main(string[] args)
    {
        // First Order (Customer in USA)
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "KB001", 29.99, 2));
        order1.AddProduct(new Product("Mouse", "MS002", 15.50, 1));

        // Second Order (Customer outside USA)
        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Alice Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Webcam", "WC003", 49.99, 1));
        order2.AddProduct(new Product("Microphone", "MC004", 79.95, 1));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
