
namespace CommandPattern.Core
{
    using System;

    using Contracts;
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "Exit")
            {
                string result = commandInterpreter.Read(input);
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
