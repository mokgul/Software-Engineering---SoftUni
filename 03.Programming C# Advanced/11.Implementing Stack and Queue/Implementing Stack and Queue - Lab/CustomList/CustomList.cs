namespace CustomList;

public class CustomList
{
    //Private Fields
    private int[] array;

    private const int Capacity = 2;

    //Constructor
    public CustomList()
    {
        this.array = new int[Capacity];
    }

    //Public Properties
    public int Count { get; private set; }

    public int this[int index]
    {
        get
        {
            if (!CheckIndex(index))
                throw new IndexOutOfRangeException();
            return array[index];
        }
        set
        {
            if (!CheckIndex(index))
                throw new IndexOutOfRangeException();
            array[index] = value;
        }
    }

    //Public Methods
    public void Add(int value)
    {
        if (Count == array.Length)
            Resize();

        array[Count] = value;
        Count++;
    }

    public int RemoveAt(int index)
    {
        if (!CheckIndex(index))
            throw new IndexOutOfRangeException();

        int removed = array[index];
        array[index] = default(int);
        Shift(index);
        Count--;

        if (Count <= array.Length / 4)
            Shrink();

        return removed;
    }

    public void Insert(int index, int value)
    {
        if (!CheckIndex(index))
            throw new IndexOutOfRangeException();

        if (Count == array.Length)
            Resize();

        ShiftRight(index);
        array[index] = value;
        Count++;
    }

    public bool Contains(int element)
    {
        for (int i = 0; i < Count; i++)
            if (array[i] == element) return true;
        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        (array[firstIndex], array[secondIndex]) = (array[secondIndex], array[firstIndex]);
    }

    public int Find(Predicate<int> element)
    {
        for (int i = 0; i < Count; i++)
            if (element(array[i]))
                return i;
        return -1;
    }

    public void Reverse()
    {
        int[] copy = new int[Count];
        int count = 0;
        for (int i = Count - 1; i >= 0; i--)
        {
            copy[count++] = array[i];
        }

        array = copy;
    }

    public override string ToString()
    {
        return string.Join(", ", array);
    }

    //Private Methods
    private void Resize()
    {
        int[] copy = new int[array.Length * 2];
        for (int i = 0; i < array.Length; i++)
            copy[i] = array[i];
        array = copy;
    }

    private void Shift(int index)
    {
        for (int i = index; i < Count - 1; i++)
            array[i] = array[i + 1];
    }

    private void ShiftRight(int index)
    {
        for (int i = Count; i > index; i--)
            array[i] = array[i - 1];
    }

    private void Shrink()
    {
        int[] copy = new int[array.Length / 2];
        for (int i = 0; i < Count; i++)
            copy[i] = array[i];
        array = copy;
    }

    private bool CheckIndex(int index)
    => index >= 0 && index < Count;
}