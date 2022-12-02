
namespace Raiding.Exceptions
{
    using System;
    public class InvalidTypeHeroException : Exception
    {
        private const string InvalidTypeHeroMessage = "Invalid hero!";
        public InvalidTypeHeroException() : base(InvalidTypeHeroMessage)
        {

        }
    }
}
