namespace Sum_Evens_in_Background
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;

            var task = Task.Run(() =>
            {
                for (long i = 0; i < 1_000_000_000; i++)
                {
                    if (i % 2 == 0)
                        sum += i;
                }
            });

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "exit")
                    return;
                else if(line == "show")
                    Console.WriteLine(sum);
            }
        }
    }
}