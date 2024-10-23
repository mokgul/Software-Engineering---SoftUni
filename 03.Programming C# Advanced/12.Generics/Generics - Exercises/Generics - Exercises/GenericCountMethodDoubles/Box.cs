using System.Text;

namespace GenericCountMethodDoubles;

public class Box<T> where T : IComparable<T>
{
    private List<T> _items;
    public Box()
    {
        _items = new List<T>();
    }


    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Swap(int indexOne, int indexTwo)
    {
        (_items[indexOne], _items[indexTwo]) = (_items[indexTwo], _items[indexOne]);
    }

    public int Count(T element)
    {
        int count = 0;
        foreach (T item in _items)
            if (item.CompareTo(element) == 1)
                count++;

        return count;
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        foreach (var item in _items)
        {
            sb.AppendLine($"{typeof(T)}: {item}");
        }

        return sb.ToString().TrimEnd();
    }
}