
using System;

namespace Telephony.Core
{
    using System.Linq;

    using Models;
    using Interfaces;
    using IO.Interfaces;
    using Exceptions;
    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly Smartphone _smartphone;
        private readonly StationaryPhone _stationaryPhone;

        private string[] _phoneNumbers;
        private string[] _urls;

        private Engine()
        {
            _smartphone = new Smartphone();
            _stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this._reader = reader;
            this._writer = writer;
        }
        public void Run()
        {
            GetPhoneNumbers();
            GetBrowserUrls();
            DialNumbers();
            BrowseURLs();
        }

        private void BrowseURLs()
        {
            foreach (var url in _urls)
            {
                try
                {
                    if (ValidateUrl(url))
                    {
                        _writer.WriteLine(_smartphone.Browse(url));
                    }
                    else
                        throw new ExceptionInvalidURL();
                }
                catch (Exception invalidUrl)
                {
                    _writer.WriteLine(invalidUrl.Message);
                }
            }
        }

        private void DialNumbers()
        {
            foreach (var phoneNumber in _phoneNumbers)
            {
                try
                {
                    if (ValidateNumber(phoneNumber))
                    {
                        _writer.WriteLine(phoneNumber.Length == 10
                            ? _smartphone.Call(phoneNumber)
                            : _stationaryPhone.Call(phoneNumber));
                    }
                    else
                        throw new ExceptionInvalidNumber();
                }
                catch (Exception invalidNumber)
                {
                    _writer.WriteLine(invalidNumber.Message);
                }
            }
        }

        private void GetBrowserUrls()
            => this._urls = this._reader.ReadLine().Split().ToArray();

        private void GetPhoneNumbers()
        => this._phoneNumbers = this._reader.ReadLine().Split().ToArray();

        private bool ValidateNumber(string number)
            => number.All(char.IsDigit);

        private bool ValidateUrl(string url)
            => !url.Any(char.IsDigit);

    }
}
