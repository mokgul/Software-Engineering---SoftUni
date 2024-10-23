
using Raiding.Exceptions;
using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding.Factories
{
    public class BaseHeroFactory : IBaseHeroFactory
    {
        public BaseHeroFactory()
        {
            
        }
        public IBaseHero CreateHero(string type, string name)
        {
            IBaseHero hero =
                type switch
                {
                    "Druid" => new Druid(name),
                    "Paladin" => new Paladin(name),
                    "Rogue" => new Rogue(name),
                    "Warrior" => new Warrior(name),
                    _ => throw new InvalidTypeHeroException()
                };
            return hero;
        }
    }
}
