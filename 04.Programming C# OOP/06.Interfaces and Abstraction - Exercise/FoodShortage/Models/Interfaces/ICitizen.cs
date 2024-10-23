
namespace FoodShortage.Models.Interfaces
{
    public interface ICitizen : IIdentifiable
    {
        int Age { get; }

        string Id { get; }

        string Birthdate { get; }
    }
}
