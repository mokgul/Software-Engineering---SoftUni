using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\');
            string lastToken = input[^1];
            //the hat operator means start counting from the end
            //the counting starts from 1
            // in { 0, 1 , 2 , 3 , 4 , 5 }
            // [^1] is the first element counting from end or 5
            // [^2] second counting from end or 4
            // [^0] == arr[arr.Lenght] and throws an error, thats why we start at 1

            int dotIndex = lastToken.IndexOf('.');
            string file = lastToken.Substring(0, dotIndex);
            string extension = lastToken.Substring(dotIndex + 1);

            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
