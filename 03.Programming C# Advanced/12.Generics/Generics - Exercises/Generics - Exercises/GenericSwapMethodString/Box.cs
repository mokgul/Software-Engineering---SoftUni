using System.Text;

namespace GenericSwapMethodString;

public class Box<T>
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