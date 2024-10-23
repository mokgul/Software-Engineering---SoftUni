
namespace Telephony.Exceptions
{
    using System;

    public class ExceptionInvalidNumber : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Invalid number!";

        public ExceptionInvalidNumber() : base(DEFAULT_EXCEPTION_MESSAGE)
        {

        }

        public ExceptionInvalidNumber(string message) : base(message)
        {

        }
    }
}
