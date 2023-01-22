
namespace Telephony.Models.Interfaces
{
    public interface ISmartphone : IStationaryPhone
    {
        string Browse(string url);
    }
}
