
namespace Telephony.Models
{
    using Interfaces;
    public class Smartphone : ISmartphone
    {
        public Smartphone() { }
        public string Call(string phoneNumber)
            => $"Calling... {phoneNumber}";

        public string Browse(string url)
            => $"Browsing: {url}!";
    }
}
