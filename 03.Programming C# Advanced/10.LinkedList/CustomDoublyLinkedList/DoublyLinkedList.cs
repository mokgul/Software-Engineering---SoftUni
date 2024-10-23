namespace CustomDoublyLinkedList;

public class DoublyLinkedList
{
    public ListNode? Head { get; set; }

    public ListNode? Tail { get; set;}

    public int Count { get; private set; }

    public void AddFirst(int element)
    {
        ListNode node = new ListNode(element);
        Count++;
        if (Head == null)
        {
            Head = node;
            Tail = node;
            return;
        }
        Head.PreviousNode = node;
        node.NextNode = Head;
        Head = node;
    }

    public void AddLast(int element)
    {
        ListNode node = new ListNode(element);
        Count++;
        if (Tail == null)
        {
            Head = node;
            Tail = node;
            return;
        }
        Tail.NextNode = node;
        node.PreviousNode = Tail;
        Tail = node;
    }

    public int RemoveFirst()
    {
        int node = Head.Value;
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }

        Count--;
        Head = Head.NextNode;

        if(Head != null)
            Head.PreviousNode = null;

        else
            Tail = null;

        return node;
    }

    public int RemoveLast()
    {
        int node = Tail.Value;
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }

        Count--;
        Tail = Tail.PreviousNode;

        if (Tail != null)
            Tail.NextNode = null;

        else
            Head = null;

        return node;
    }

    public void ForEach(Action<int> action)
    {
        ListNode node = Head;
        while (node != null)
        {
            action(node.Value);
            node = node.NextNode;
        }
    }

    public int[] ToArray()
    {
        int[] array = new int[this.Count];
        int counter = 0;
        var node = Head;
        while (node != null)
        {
            array[counter++] = node.Value;
            node = node.NextNode;
        }
        return array;
    }
}