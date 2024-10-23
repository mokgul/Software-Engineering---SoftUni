namespace Chronometer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            string line;

            while ((line = Console.ReadLine()) != "exit")
            {
                switch (line)
                {
                    case "start": Task.Run(() => { chronometer.Start(); }); break;
                    case "stop": Task.Run(() => { chronometer.Stop(); }); break;
                    case "lap": Task.Run(() => { Console.WriteLine(chronometer.Lap()); }); break;
                    case "laps":
                        
                            if(chronometer.Laps.Count == 0)
                            {
                                Console.WriteLine("Laps: no laps");
                                continue;
                            }

                            Console.WriteLine("Laps: ");
                            for(int i = 0; i < chronometer.Laps.Count; i++)
                                Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                            break;
                    case "reset": chronometer.Reset(); break;
                    case "time": Console.WriteLine(chronometer.GetTime); break;
                }
            }
            chronometer.Stop();
        }
    }
}