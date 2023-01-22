
namespace MilitaryElite.Models
{
    using Interfaces;
    public class Repair : IRepair
    {
        public Repair(string name, int hoursWorked)
        {
            PartName = name;
            HoursWorked = hoursWorked;
        }
        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }

        public override string ToString()
            => $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}
