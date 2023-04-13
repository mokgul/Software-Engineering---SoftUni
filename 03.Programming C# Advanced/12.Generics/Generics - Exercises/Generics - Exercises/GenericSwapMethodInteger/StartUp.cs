namespace GenericSwapMethodInteger;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine()!);
        Box<int> box = new Box<int>();

        for (int i = 0; i < lines; i++)
            box.Add(int.Parse(Console.ReadLine()!));

        int[] indices = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        box.Swap(indices[0], indices[1]);
        Console.WriteLine(box.ToString());
    }
}
