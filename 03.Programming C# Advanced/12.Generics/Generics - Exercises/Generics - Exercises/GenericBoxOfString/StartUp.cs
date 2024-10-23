namespace GenericBoxOfString;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < lines; i++)
            Console.WriteLine(
                new Box<string>(Console.ReadLine()!)
                    .ToString());
    }
}
