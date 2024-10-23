namespace GenericSwapMethodString;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine()!);
        Box<string> box = new Box<string>();

        for (int i = 0; i < lines; i++)
            box.Add(Console.ReadLine()!);

        int[] indices = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        box.Swap(indices[0], indices[1]);
        Console.WriteLine(box.ToString());
    }
}
