
namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;
        public Warrior(string name) : base(name, POWER)
        {
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
