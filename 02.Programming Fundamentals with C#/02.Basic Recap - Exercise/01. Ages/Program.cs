using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            string age_ = "";
            int age     = int.Parse(Console.ReadLine());
            switch (age)
            {
                case int n when (n >= 0 && n <= 2):   age_ = "baby";     break;
                case int n when (n >= 3 && n <= 13):  age_ = "child";    break;
                case int n when (n >= 14 && n <= 19): age_ = "teenager"; break;
                case int n when (n >= 20 && n <= 65): age_ = "adult";    break;
                case int n when (n >=66 ):            age_ = "elder";    break;
            }
            Console.WriteLine(age_);
        }
    }
}