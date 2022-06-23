using System;
using Exercise002.Entities;
using Exercise002.Entities.Enums;
using System.Globalization;
using System.Collections.Generic;

namespace Exercise002
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cliente Data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Order Data:");
            Console.Write("Status: ");
            OrderStatus orderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());
            DateTime moment = DateTime.Now;

            Client client = new Client(name, email, birthDate);

            Order order = new Order(moment, orderStatus, client);


            Console.Write("How many itens to this order? ");
            int it = int.Parse(Console.ReadLine());

            for(int i = 1; i <= it; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameItem = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());

                Product product = new Product(nameItem, price);

                OrderItem o = new OrderItem(quant, price, product);

                order.AddItem(o);

            }
            Console.WriteLine();
            Console.WriteLine(order);

        }
    }
}
