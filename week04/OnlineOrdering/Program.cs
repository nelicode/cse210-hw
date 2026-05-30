using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "111 Main Street",
            "Portland",
            "OR",
            "USA");

        Customer customer1 = new Customer(
            "Nelida Smith",
            address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(
            new Product(
                "Camera",
                "P100",
                800,
                1));

        order1.AddProduct(
            new Product(
                "Mouse",
                "P101",
                25,
                2));



        Address address2 = new Address(
            "123 Maple Street",
            "Springfield",
            "IL",
            "USA");

        Customer customer2 = new Customer(
            "Lucia",
            address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(
            new Product(
                "Keyboard",
                "P200",
                50,
                1));

        order2.AddProduct(
            new Product(
                "Monitor",
                "P201",
                200,
                1));

        order2.AddProduct(
            new Product(
                "Headphones",
                "P202",
                40,
                2));



        Console.WriteLine("===== ORDER 1 =====");

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine(
            $"\nTotal Cost: ${order1.CalculateTotalCost()}");



        Console.WriteLine("\n==============================");



        Console.WriteLine("\n===== ORDER 2 =====");

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine(
            $"\nTotal Cost: ${order2.CalculateTotalCost()}");
    }
}