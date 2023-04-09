namespace CustomList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            for (int i = 0; i < 15; i++)
            {
                list.Add(new Random().Next(0, 150));
            }
            list.Reverse();
            Console.WriteLine(list.Find(x => x == 12));
            Console.WriteLine(list.ToString());
        }
    }
}