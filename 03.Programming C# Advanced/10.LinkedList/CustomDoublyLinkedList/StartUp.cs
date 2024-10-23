namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.AddFirst(3);
            list.AddLast(2);
            list.AddFirst(1);
            list.RemoveFirst();
            list.AddLast(21);
            list.AddFirst(7);
            list.RemoveLast();
            list.AddFirst(13);
            list.AddLast(5);

            list.ForEach(action => Console.WriteLine(action));
        }
    }
}