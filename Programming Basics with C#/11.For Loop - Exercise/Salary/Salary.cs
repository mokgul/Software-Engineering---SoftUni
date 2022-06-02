using System;

namespace Salary
{
    class Salary
    {
        static void Main(string[] args)
        {
            //declaration
            int tabs = 0;
            int salary = 0;
            string site = " ";

            //input
            tabs = int.Parse(Console.ReadLine());
            salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < tabs; i++)
            {
                site = Console.ReadLine();
                switch (site)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
                        break;
                    default:
                        salary += 0;
                        break;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            //output
            if (salary > 0)
                Console.WriteLine(salary);
        }
    }
}
