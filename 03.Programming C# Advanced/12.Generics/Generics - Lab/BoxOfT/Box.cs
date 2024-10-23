namespace BoxOfT;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public T Remove()
    {
        T item = items.Last();
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public int Count => items.Count;
}