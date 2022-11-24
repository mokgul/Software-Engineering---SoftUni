namespace PersonInfo
{
    public interface IPerson : IBirthable, IIdentifiable
    {
        string Name { get; }
        int Age { get; }
    }
}
