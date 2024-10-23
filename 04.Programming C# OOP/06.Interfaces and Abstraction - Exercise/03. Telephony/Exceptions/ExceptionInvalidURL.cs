
namespace Telephony.Exceptions
{
    using System;

    public class ExceptionInvalidURL : Exception
    {
        private const string DEFAULT_EXCEPTION_MSG = "Invalid URL!";

        public ExceptionInvalidURL() : base(DEFAULT_EXCEPTION_MSG)
        {

        }

        public ExceptionInvalidURL(string message) : base(message)
        {

        }
    }
}
