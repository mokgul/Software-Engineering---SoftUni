using System;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string info = Console.ReadLine();

                int nameStart = info.IndexOf('@');
                int nameEnd = info.IndexOf('|');
                string name = info.Substring(nameStart + 1, nameEnd - nameStart - 1);

                int ageStart = info.IndexOf('#');
                int ageEnd = info.IndexOf('*');
                string age = info.Substring(ageStart + 1, ageEnd - ageStart - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
