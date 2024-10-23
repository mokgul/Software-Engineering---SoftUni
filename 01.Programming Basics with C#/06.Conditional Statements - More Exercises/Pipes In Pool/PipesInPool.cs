using System;

namespace Pipes_In_Pool
{
    class PipesInPool
    {
        static void Main(string[] args)
        {
            int poolVolume         = int.Parse(Console.ReadLine());
            int firstPipeFlowrate  = int.Parse(Console.ReadLine());
            int secondPipeFlowrate = int.Parse(Console.ReadLine());
            double hoursWorkerGone = double.Parse(Console.ReadLine());

            double firstPipeVolume   = firstPipeFlowrate * hoursWorkerGone;
            double secondPipeVolume  = secondPipeFlowrate * hoursWorkerGone; 
            double totalVolumeFilled = firstPipeVolume + secondPipeVolume;
            double totalVolumeFilledPercent = (totalVolumeFilled / poolVolume) * 100;
            double firstPipeVolumePercent   = (firstPipeVolume / totalVolumeFilled) * 100;
            double secondPipeVolumePercent  = (secondPipeVolume / totalVolumeFilled) * 100;

            if (totalVolumeFilled <= poolVolume)
                Console.WriteLine($"The pool is {totalVolumeFilledPercent:f2}% full.Pipe 1: {firstPipeVolumePercent:f2}%. Pipe 2: {secondPipeVolumePercent:f2}%.");
            else
                Console.WriteLine($"For {hoursWorkerGone} hours the pool overflows with {(totalVolumeFilled - poolVolume):f2} liters.");
        }
    }
}
