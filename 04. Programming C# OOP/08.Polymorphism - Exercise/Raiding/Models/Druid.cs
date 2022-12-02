
namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;
        public Druid(string name) : base(name, POWER)
        {
            
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
