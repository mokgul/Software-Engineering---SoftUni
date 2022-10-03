using System;
using System.Linq;
using System.Threading.Channels;
using System.Xml.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            //samples info
            int[] samples = new int[length];
            int seqLength = 0;
            int elementSum = 0;
            int startingIndex = 0;
            //current best Sample info
            int[] bestSample = new int[length];
            int bestLength = 0;
            int bestElementSum = 0;
            int lowestIndex = length;
            int bestSequenceIndex = 0;
            //lowest gets the value of length, this way it always be higher than any index of the array
            int sequenceIndex = 0;

            string command = Console.ReadLine();
            while (command != "Clone them!")
            {
                elementSum = 0;
                sequenceIndex++;
                samples = command.Split("!",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                //calculating Sum of elements
                for (int i = 0; i < samples.Length; i++)
                {
                    elementSum += samples[i];
                }

                //getting length of repeating elements
                int counter = 1;

                for (int i = 0; i < samples.Length - 1; i++)
                {
                    if ((samples[i] == samples[i + 1]) && samples[i] != 0)
                    {
                        counter++;
                        if (counter == 2)
                            startingIndex = i;
                        // getting index where sequence starts
                    }

                    else
                    {
                        counter = 1;
                    }

                    if (seqLength < counter)
                    {
                        seqLength = counter;
                    }
                }

                bool getStats = false;
                if (seqLength > bestLength)
                {
                    getStats = true;
                }
                else if (seqLength == bestLength)
                {
                    if (startingIndex < lowestIndex)
                    {
                        getStats = true;
                    }
                    else
                    {
                        if (elementSum > bestElementSum)
                        {
                            getStats = true;
                        }
                    }
                }

                if (getStats)
                {
                    bestSample = samples;
                    bestLength = seqLength;
                    bestElementSum = elementSum;
                    lowestIndex = startingIndex;
                    bestSequenceIndex = sequenceIndex;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestElementSum}.");
            Console.WriteLine(string.Join(" ", bestSample));
        }
    }
}