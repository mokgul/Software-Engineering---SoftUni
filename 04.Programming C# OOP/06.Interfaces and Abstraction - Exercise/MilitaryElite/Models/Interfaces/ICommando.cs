
namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}