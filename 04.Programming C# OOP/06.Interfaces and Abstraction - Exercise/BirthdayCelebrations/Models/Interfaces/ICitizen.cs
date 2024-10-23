
namespace BirthdayCelebrations.Models.Interfaces
{
    public interface ICitizen : IBirthdate
    {
        string Name { get; }
        int Age { get; }
        string Id { get; }
        
    }
}
