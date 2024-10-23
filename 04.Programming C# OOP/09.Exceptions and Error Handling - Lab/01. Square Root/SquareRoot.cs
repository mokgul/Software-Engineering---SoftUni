
namespace _01._Square_Root
{
    using System;
    public class SquareRoot
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            try
            {
                if (number < 0)
                    throw new ArgumentException("Invalid number.");
                Console.WriteLine(Sqrt(number));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        private static double Sqrt(int number)
        => Math.Sqrt(number);
    }
}
