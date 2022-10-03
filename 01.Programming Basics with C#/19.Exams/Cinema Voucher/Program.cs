using System;

namespace Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int price = 0;
            int tickets = 0;
            int others = 0;
            int voucher = int.Parse(Console.ReadLine());
            string buys = Console.ReadLine();
            while (buys != "End")
            {
                if (buys.Length > 8)
                {
                    price = buys[0] + buys[1];
                    if (price <= voucher)
                    {
                        voucher -= price;
                        tickets++;
                    }
                    else
                        break;
                }
                else
                {
                    price = buys[0];
                    if (price <= voucher)
                    {
                        voucher -= price;
                        others++;
                    }
                    else
                        break;
                }
                buys = Console.ReadLine();
            }
            Console.WriteLine(tickets);
            Console.WriteLine(others);
        }
    }
}