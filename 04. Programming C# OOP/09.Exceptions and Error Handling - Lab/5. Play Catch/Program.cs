
using System.Linq;

namespace _5._Play_Catch
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();
            var exceptionCounter = 0;
            while (exceptionCounter < 3)
            {
                var input = Console.ReadLine().Split();
                try
                {
                    var command = input[0];
                    int index;
                    try
                    {
                        index = int.Parse(input[1]);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("The variable is not in the correct format!");
                    }

                    if (index < 0 || index > integers.Length - 1)
                        throw new ArgumentException("The index does not exist!");
                    switch (command)
                    {
                        case "Replace":
                        {
                            var element = int.Parse(input[2]);
                            integers[index] = element;
                            break;
                        }
                        case "Print":
                        {
                            var endIndex = int.Parse(input[2]);
                            if (endIndex < 0 || endIndex > integers.Length - 1)
                                throw new ArgumentException("The index does not exist!");
                            int[] temp = new int[endIndex - index + 1];
                            int tempIndex = 0;
                            for(var i = index; i <= endIndex; i++)
                            {
                               temp[tempIndex] = (integers[i]);
                               tempIndex++;
                            }

                            Console.WriteLine(string.Join(", ", temp));
                            break;
                        }
                        case "Show":
                            Console.WriteLine(integers[index]);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    exceptionCounter++;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    exceptionCounter++;
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
