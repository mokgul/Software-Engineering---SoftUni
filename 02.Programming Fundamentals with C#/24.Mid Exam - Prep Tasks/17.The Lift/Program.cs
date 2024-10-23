using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> lift = Console.ReadLine().Split().Select(int.Parse).ToList();
            int peopleInWagon = 0;
            int peopleInLift = 0;
            bool noMorePeople = false;

            for (int i = 0; i < lift.Count; i++)
            {
                while (lift[i] < 4)
                {
                    lift[i]++;
                    peopleInWagon++;
                    if (peopleInLift + peopleInWagon == people)
                    {
                        noMorePeople = true;
                        break;
                    }
                }

                peopleInLift += peopleInWagon;
                if (noMorePeople)
                {
                    break;
                }

                peopleInWagon = 0;
            }

            if (people > peopleInLift)
            {
                Console.WriteLine($"There isn't enough space! {people - peopleInLift} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (people < lift.Count * 4 && lift.Any(w => w < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (lift.All(w => w == 4) && noMorePeople == true)
            {
                Console.WriteLine(string.Join(" ", lift));
            }
        }
    }
}
