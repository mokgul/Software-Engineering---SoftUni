
namespace BirthdayCelebrations
{
    using System;

    using IO;
    using IO.Interfaces;
    using Core;
    using Core.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}
