using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(new Child(
            //    Console.ReadLine(),
            //    int.Parse(Console.ReadLine())));
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
    }
}
