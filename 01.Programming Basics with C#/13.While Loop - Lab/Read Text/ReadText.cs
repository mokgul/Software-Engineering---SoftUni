using System;

namespace Read_Text
{
    class ReadText
    {
        static void Main(string[] args)
        {
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                Console.WriteLine(input);

            }
        }
    }
}
