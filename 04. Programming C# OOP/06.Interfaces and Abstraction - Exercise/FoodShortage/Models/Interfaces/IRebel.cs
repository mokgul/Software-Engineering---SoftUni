
namespace FoodShortage.Models.Interfaces
{
    public interface IRebel : IIdentifiable
    {
        int Age { get; }

        string Group { get; }
    }
}
