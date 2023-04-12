namespace CustomQueue
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            CustomQueue stack  = new CustomQueue();
            for (int i = 0; i < 15; i++)
            {
                stack.Enqueue(new Random().Next(0, 150));
            }

            stack.Clear();
        }
    }
}