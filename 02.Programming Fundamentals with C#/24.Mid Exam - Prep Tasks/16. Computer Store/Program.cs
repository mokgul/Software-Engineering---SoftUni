using System;

namespace _16._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var total = 0.0;
            var tax = 0.20;
            var taxPrices = 0.0;
            var priceBeforeTax = 0.0;
            string input = Console.ReadLine();
            while (input != "special" && input != "regular")
            {
                var price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                priceBeforeTax += price;
                taxPrices += price * tax;
                total += price + price * tax;
                input = Console.ReadLine();
            }

            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            total = input == "special" ? total *= 0.90 : total;
            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {priceBeforeTax:f2}$");
            Console.WriteLine($"Taxes: {taxPrices:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:f2}$");
        }
    }
}
