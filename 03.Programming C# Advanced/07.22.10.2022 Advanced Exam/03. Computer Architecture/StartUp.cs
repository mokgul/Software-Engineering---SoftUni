using System;

namespace ComputerArchitecture
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer("Gaming Serioux", 4);

            CPU cpu = new CPU("AMD Ryzen 5", 6, 3.7);

            Console.WriteLine(cpu); 

            computer.Add(cpu);

            Console.WriteLine(computer.Remove("Intel Core i5"));
            
            CPU secondCPU = new CPU("Intel Core i7", 8, 4);
            CPU thirdCPU = new CPU("Intel Core i5", 8, 3.9);

            computer.Add(secondCPU);
            computer.Add(thirdCPU);

            CPU mostPowerful = computer.MostPowerful();
            Console.WriteLine (mostPowerful);

            CPU receivedCPU = computer.GetCPU("Intel Core i5");
            Console.WriteLine(receivedCPU);

            Console.WriteLine(computer.Count); 

            Console.WriteLine(computer.Remove("Intel Core i5")); 

            Console.WriteLine(computer.Report());
        }
    }
}
