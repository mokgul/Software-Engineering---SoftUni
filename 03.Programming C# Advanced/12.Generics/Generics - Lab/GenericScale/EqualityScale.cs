namespace GenericScale;

public class EqualityScale<T>
{
    private readonly T _left;
    private readonly T _right;

    public EqualityScale(T left, T right)
    {
        _left = left;
        _right = right;
    }

    public bool AreEqual() => _left!.Equals(_right);
    
}