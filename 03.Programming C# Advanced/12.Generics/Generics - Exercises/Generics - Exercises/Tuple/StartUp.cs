namespace Tuple;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] personInfo = Console.ReadLine()!.Split().ToArray();
        string[] personBeer = Console.ReadLine()!.Split().ToArray();
        string[] numbers = Console.ReadLine()!.Split().ToArray();

        int addressCount = personInfo.Length - 2;
        CustomTuple<string, string> info = new CustomTuple<string, string>(
            personInfo[0] + " " + personInfo[1],
            string.Join(" ", personInfo, 2, addressCount)
        );

        CustomTuple<string, int> beer = new CustomTuple<string, int>(
            personBeer[0], int.Parse(personBeer[1])
        );

        CustomTuple<int, double> num = new CustomTuple<int, double>(
            int.Parse(numbers[0]), double.Parse(numbers[1])
        );

        Console.WriteLine(info);
        Console.WriteLine(beer);
        Console.WriteLine(num);
    }
}
