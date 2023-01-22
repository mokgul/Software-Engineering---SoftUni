

namespace VehiclesExtension
{
    using Core;
    using Core.Interfaces;
    using IO;
    using IO.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}

// have a few errors to fix, refuel doesnt work properly, drive doesnt work properly,
//wrong calculations is my guess
