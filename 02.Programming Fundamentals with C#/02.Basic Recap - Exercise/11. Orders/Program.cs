using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = 0;
            int capsules_count = 0;
            double capsule_price = 0;
            
            double order_price = 0;
            double total_price = 0;
            int orders_count = int.Parse(Console.ReadLine());
            
            for(int order = 1; order <= orders_count; order++)
            {
                capsule_price = double.Parse(Console.ReadLine());
                days = int.Parse(Console.ReadLine());
                capsules_count = int.Parse(Console.ReadLine());
                order_price = ((days * capsules_count) * capsule_price);
                total_price += order_price;

                Console.WriteLine($"The price for the coffee is: ${order_price:f2}");
            }
            Console.WriteLine($"Total: ${total_price:f2}");
        }
    }
}