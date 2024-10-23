using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumset = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> initialValues = drumset;

            var command = Console.ReadLine();
            while (command != "Hit it again, Gabsy!")
            {
                var hitPower = int.Parse(command);
                drumset = drumset.Select(x => x -= hitPower).ToList();
                bool isZero = drumset.Any(x => x <= 0);
                if(isZero)
                {
                    for (int i = 0; i < drumset.Count; i++)
                    {
                        if (drumset[i] <= 0)
                        {
                            if(savings >= initialValues[i] * 3)
                            {
                                drumset[i] = initialValues[i];
                                savings -= initialValues[i] * 3;
                            }
                            else
                            {
                                drumset.RemoveAt(i);
                                initialValues.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",drumset));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
