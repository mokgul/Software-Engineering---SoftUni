using System;

namespace CustomStack;

public class CustomStack
{
    //Private fields
    private const int Capacity = 4;
    private int[] items;
    private int count;

    //Constructor
    public CustomStack()
    {
        count = 0;
        items = new int[Capacity];
    }

    //Public properties
    public int Count => count;

    //Public methods
    public void Push(int item)
    {
        if(items.Length == count)
            Resize();

        items[count] = item;
        count++;
    }

    public int Pop()
    {
        if (items.Length == 0)
            throw new InvalidOperationException("CustomStack is empty");

        var removed = items[count - 1];
        int[] copy = new int[items.Length - 1];

        for(int i = 0; i < count; i++)
            copy[i] = items[i];

        items = copy;
        count--;
        return removed;
    }

    public int Peek()
    {
        if (items.Length == 0)
            throw new InvalidOperationException("CustomStack is empty");

        int item = items[count - 1];
        return item;
    }

    public void ForEach(Action<int> action)
    {
        for(int i = 0; i < count; i++)
            action(items[i]);
    }

    //Private methods
    private void Resize()
    {
        int[] copy = new int[items.Length * 2];
        for (int i = 0; i < items.Length; i++)
            copy[i] = items[i];
        items = copy;
    }
}