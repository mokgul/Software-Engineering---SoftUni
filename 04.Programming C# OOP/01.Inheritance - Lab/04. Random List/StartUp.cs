using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList(){"121","1233132","23213"};
            Console.WriteLine(list.RandomString());
            
        }
    }
}
