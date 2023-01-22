
using Raiding.Models.Interfaces;

namespace Raiding.Factories.Interfaces
{
    public interface IBaseHeroFactory
    {
        IBaseHero CreateHero(string type, string name);
    }
}
