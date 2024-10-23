
namespace Animals
{
    using System;
    public class Dog : Animal
    {
        public Dog(string name, string food) : base(name, food)
        {
        }

        public override string ExplainSelf()
            => $"{base.ExplainSelf()}" + Environment.NewLine + "DJAAF";
    }
}
