namespace Threeuple;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] personInfo = Console.ReadLine()!.Split().ToArray();
        string[] personBeer = Console.ReadLine()!.Split().ToArray();
        string[] bankInfo = Console.ReadLine()!.Split().ToArray();

        int addressCount = personInfo.Length - 3;

        CustomThreeuple<string, string, string> person = new CustomThreeuple<string, string, string>(
            personInfo[0] + " " + personInfo[1],
            personInfo[2],
            string.Join(" ", personInfo, 3, addressCount)
        );

        CustomThreeuple<string, int, bool> drunk = new CustomThreeuple<string, int, bool>(
            personBeer[0], int.Parse(personBeer[1]), personBeer[2] == "drunk"
        );

        CustomThreeuple<string, double, string> bank = new CustomThreeuple<string, double, string>(
            bankInfo[0], double.Parse(bankInfo[1]), bankInfo[2]
        );

        Console.WriteLine(person);
        Console.WriteLine(drunk);
        Console.WriteLine(bank);
    }
}
