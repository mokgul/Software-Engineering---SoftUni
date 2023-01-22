
namespace Telephony.Models
{
    using Interfaces;
    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone() { }

        public string Call(string phoneNumber)
            => $"Dialing... {phoneNumber}";
    }
}
