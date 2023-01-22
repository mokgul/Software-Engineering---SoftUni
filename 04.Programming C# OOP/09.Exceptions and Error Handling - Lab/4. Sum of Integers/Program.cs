using System;

namespace _4._Sum_of_Integers
{
    internal class Program
    {
        private const string WrongFormat = "The element '{0}' is in wrong format!";
        private const string OutOfRange = "The element '{0}' is out of range!";
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int sum = 0;
            foreach (var element in input)
            {
                try
                {
                    sum += CheckNumber(element);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        private static int CheckNumber(string num)
        {
            int n;
            try
            {
                n = int.Parse(num);
            }
            catch (FormatException)
            {
                throw new FormatException(string.Format(WrongFormat, num));
            }
            catch (OverflowException)
            {
                throw new OverflowException(string.Format(OutOfRange, num));
            }
            return n;
        }
    }
}
