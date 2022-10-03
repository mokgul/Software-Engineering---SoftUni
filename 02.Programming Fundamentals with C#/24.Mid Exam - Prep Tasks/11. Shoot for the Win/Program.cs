using System;
using System.Drawing;
using System.Linq;

namespace _11._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while (input != "End")
            {
                int index = int.Parse(input);
                bool validIndex = index >= 0 && index < targets.Length;

                if (validIndex)
                {
                    bool isTargetShot = targets[index] == -1;
                    if (!isTargetShot)
                    {
                        int tempValue = targets[index];
                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i] == -1) continue;
                            if (i == index)
                                targets[index] = -1;
                            else
                            {
                                if (targets[i] > tempValue)
                                    targets[i] -= tempValue;
                                else
                                    targets[i] += tempValue;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            int shotTargets = targets.Count(x => x == -1);
            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", targets)}");
        }
    }
}
