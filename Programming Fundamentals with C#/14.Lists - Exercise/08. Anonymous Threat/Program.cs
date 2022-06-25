using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            data = Commands(data);
            Console.WriteLine(string.Join(" ",data));
        }

        private static List<string> Commands(List<string> data)
        {
            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] command = input.Split(" ");
                switch (command[0])
                {
                    case "merge":
                        data = Merge(data, command);
                        break;
                    case "divide":
                        data = Divide(data, command);
                        break;
                }
                input = Console.ReadLine();
            }
            return data;
        }

        private static List<string> Merge(List<string> data, string[] command)
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);

            if (startIndex < 0) startIndex = 0;
            if (startIndex > data.Count - 1) startIndex = data.Count - 1;

            if (endIndex < 0) endIndex = 0;
            if (endIndex > data.Count - 1) endIndex = data.Count - 1;
            
            List<string> temp = new List<string>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                temp.Add(data[i]);
                //add to a temp list the elements we want to merge
            }

            data[startIndex] = string.Join("", temp);

            //the value at startIndex in data becomes temp
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                data.RemoveAt(startIndex + 1);
                //removes the items between the starting and ending index
            }

            return data;
        }

        private static List<string> Divide(List<string> data, string[] command)
        {
            int index = int.Parse(command[1]);
            int partition = int.Parse(command[2]);

            List<string> temp = new List<string>();
            string toDivide = data[index];
            int partitionLength = toDivide.Length / partition;
            int additionalPartLength = toDivide.Length % partition;
            //this will be 0 if the amount of substrings is even number

            for (int i = 0; i < partition; i++)
            {
                if (i == partition - 1)
                    partitionLength += additionalPartLength;
                //adds the additional length to the last element
                temp.Add(toDivide.Substring(0,partitionLength));
                //adds in temp the substring from toDivide from index 0 to the length of the partition
                toDivide = toDivide.Remove(0, partitionLength);
                //removes from toDivide the substring we just added
            }

            data.RemoveAt(index);
            //removes the original string
            data.InsertRange(index,temp);
            //insert the new list temp to data from the given index

            return data;
        }
    }
}
