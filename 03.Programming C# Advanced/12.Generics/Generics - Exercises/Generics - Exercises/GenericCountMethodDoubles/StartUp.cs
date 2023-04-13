namespace GenericCountMethodDoubles;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine()!);
        Box<double> box = new Box<double>();

        for (int i = 0; i < lines; i++)
            box.Add(double.Parse(Console.ReadLine()!));

        Console.WriteLine(
            box.Count(
                double.Parse(Console.ReadLine()!)));
    }
}
