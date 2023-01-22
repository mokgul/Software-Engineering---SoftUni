

namespace BorderControl.Core
{
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;
    using IO.Interfaces;
    using System;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly List<string> _ids;
        private Engine()
        {
            _ids = new List<string>();
        }

        public Engine(IReader reader, IWriter writer) : this() 
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            ReceiveInformation();
            DetainFakeIds();
        }

        private void DetainFakeIds()
        {
            string fake = _reader.ReadLine();
            _writer.WriteLine(string.Join(Environment.NewLine,
                _ids.Where(id => id.EndsWith(fake))));
        }

        private void ReceiveInformation()
        {
            string input = _reader.ReadLine();
            while (input != "End")
            {
                _ids.Add(input.Split().Last());
                input = _reader.ReadLine();
            }
        }
    }
}
