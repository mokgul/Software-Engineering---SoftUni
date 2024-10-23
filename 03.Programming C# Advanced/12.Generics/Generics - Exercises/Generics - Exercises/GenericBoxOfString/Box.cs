namespace GenericBoxOfString;

public class Box<T>
{
    public Box(T item)
    {
        Value = item;
    }

    public T Value { get; set; }

    public override string ToString()
        => $"{typeof(T)}: {Value}";
}