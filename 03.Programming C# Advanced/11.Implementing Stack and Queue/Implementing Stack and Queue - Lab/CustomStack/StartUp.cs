namespace CustomStack
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack stack  = new CustomStack();
            for (int i = 0; i < 100; i++)
            {
                stack.Push(new Random().Next(0, 150));
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(stack.Pop());
            }
            stack.ForEach(i => Console.Write(i.ToString() + ' '));
        }
    }
}