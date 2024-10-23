
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    using Interfaces;
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
        : base(id,firstName,lastName,salary)
        {
            Corps = corps;
        }
        public Corps Corps { get; private set; }
    }
}
