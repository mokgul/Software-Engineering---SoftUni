using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule =
                Console.ReadLine()
                    .Split(new string[] {", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            schedule = Commands(schedule);
            PrintList(schedule);
        }

        private static void PrintList(List<string> schedule)
        {
            int index = 1;
            foreach (var item in schedule)
            {
                Console.WriteLine($"{index}.{item}");
                index++;
            }
        }

        private static List<string> Commands(List<string> schedule)
        {
            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] command = input.Split(":");
                switch (command[0])
                {
                    case "Add":
                        schedule = AddToSchedule(schedule, command);
                        break;
                    case "Insert":
                        schedule = InsertToSchedule(schedule, command);
                        break;
                    case "Remove":
                        schedule = RemoveFromSchedule(schedule, command);
                        break;
                    case "Swap":
                        schedule = SwapInSchedule(schedule, command);
                        break;
                    case "Exercise":
                        schedule = AddExercise(schedule, command);
                        break;
                }
                input = Console.ReadLine();
            }

            return schedule;
        }

        private static List<string> AddToSchedule(List<string> schedule, string[] command)
        {
            string lessonToAdd = command[1];
            bool InList = CheckIfExist(schedule, lessonToAdd);
            if (!InList)
            {
                schedule.Add(lessonToAdd);
            }
            return schedule;
        }

        private static List<string> InsertToSchedule(List<string> schedule, string[] command)
        {
            string lessonToAdd = command[1];
            int index = int.Parse(command[2]);
            bool InList = CheckIfExist(schedule, lessonToAdd);
            if (!InList)
            {
                schedule.Insert(index, lessonToAdd);
            }

            return schedule;
        }

        private static List<string> RemoveFromSchedule(List<string> schedule, string[] command)
        {
            string lessonToRemove = command[1];
            string lessonExer = command[1] + "-Exercise";
            bool exeInList = CheckIfExist(schedule, lessonExer);
            bool inList = CheckIfExist(schedule, lessonToRemove);
            if (inList)
            {
                schedule.Remove(lessonToRemove);
                if (exeInList)
                    schedule.Remove(lessonExer);
            }

            return schedule;
        }

        private static List<string> SwapInSchedule(List<string> schedule, string[] command)
        {
            string lessonOne = command[1];
            string lessonOneExe = command[1] + "-Exercise";
            string lessonTwo = command[2];
            string lessonTwoExe = command[2] + "-Exercise";

            bool firstInList = CheckIfExist(schedule, lessonOne);
            bool secondInList = CheckIfExist(schedule, lessonTwo);
            bool firstExeInList = CheckIfExist(schedule, lessonOneExe);
            bool secondExeInList = CheckIfExist(schedule, lessonTwoExe);

            int indexFirst = schedule.IndexOf(lessonOne);
            int indexSecond = schedule.IndexOf(lessonTwo);

            if (firstInList && secondInList)
            {
                string temp = lessonOne; // holds the value of lessonOne
                schedule[indexFirst] = lessonTwo; // first gets the value of second
                schedule[indexSecond] = temp; // seconds gets the value of first
                if(firstExeInList) // if there is - exercise after first lesson
                {
                    schedule.RemoveAt(indexFirst + 1); // the exercise is not swapped so its still
                    //on the next index after first
                    schedule.Insert(schedule.IndexOf(lessonOne) + 1, lessonOneExe);
                    //to put it after the first lesson, we get first lesson' index and add the
                    //exercise on the next one
                    
                }

                if(secondExeInList)
                {
                    schedule.RemoveAt(indexSecond + 1);
                    schedule.Insert(schedule.IndexOf(lessonTwo) + 1, lessonTwoExe);
                }
            }

            return schedule;
        }

        private static List<string> AddExercise(List<string> schedule, string[] command)
        {
            string exerToAdd = command[1] + "-Exercise";
            int lessonIndex = schedule.IndexOf(command[1]);

            bool lessonInList = CheckIfExist(schedule, command[1]);
            if (lessonInList)
            {
                bool exeinList = CheckIfExist(schedule, exerToAdd);
                if (!exeinList)
                {
                    schedule.Insert(lessonIndex + 1, exerToAdd);
                }
            }
            else
            {
                schedule.Add(command[1]);
                schedule.Add(exerToAdd);
            }

            return schedule;
        }

        private static bool CheckIfExist(List<string> schedule, string lesson)
        {
            if(schedule.Contains(lesson))
                return true;
            return false;
        }
    }
}
