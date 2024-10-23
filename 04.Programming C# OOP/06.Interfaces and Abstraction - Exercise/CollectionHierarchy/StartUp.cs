
using CollectionHierarchy.Core;
using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.IO;
using CollectionHierarchy.IO.Interfaces;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
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
