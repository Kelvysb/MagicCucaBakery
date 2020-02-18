using System;

namespace MagicCucaBakery.Domain.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string message) : base($"User not authorized: {message}")
        {
            UserLogin = message;
        }

        public string UserLogin { get; private set; }
    }
}
