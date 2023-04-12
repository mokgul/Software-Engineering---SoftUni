namespace CustomQueue;

public class CustomQueue
{
    private int[] items;
    private const int Capacity = 4;
    private const int FirstElementIndex = 0;
    private int count;

    public CustomQueue()
    {
        count = 0;
        this.items = new int[Capacity];
    }

    public int Count => count;

    public void Enqueue(int item)
    {
        if (items.Length == count)
            Resize();

        int[] copy = new int[items.Length + 1];
        Array.Copy(items, 0, copy, 1, items.Length);

        copy[FirstElementIndex] = item;
        items = copy;
        count++;
       
    }

    public int Dequeue()
    {
        IsEmpty();
        count--;
        var removed = items[FirstElementIndex];
        items[FirstElementIndex] = default;

        for (int i = 1; i < items.Length; i++)
            items[i - 1] = items[i];

        items[^1] = default;
        return removed;

    }

    public int Peek()
    {
        IsEmpty();
        return items[FirstElementIndex];
    }

    public void Clear()
    {
        Array.Clear(items, 0, Count);
    }

    public void ForEach(Action<int> action)
    {
        for(int i = 0; i < count; i++)
            action(items[i]);
    }

    private void Resize()
    {
        int[] copy = new int[items.Length * 2];
        for (int i = 0; i < items.Length; i++)
            copy[i] = items[i];
        items = copy;
    }

    private bool IsEmpty()
    {
        if (count == 0)
            throw new InvalidOperationException("The queue is empty");
        return true;
    }
}