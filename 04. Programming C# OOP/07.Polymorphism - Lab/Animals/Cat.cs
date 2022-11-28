
namespace Animals
{
    using System;
    public class Cat : Animal
    {
        public Cat(string name, string food) : base(name, food)
        {
        }

        public override string ExplainSelf()
            => $"{base.ExplainSelf()}" + Environment.NewLine + "MEEOW";
    }
}
