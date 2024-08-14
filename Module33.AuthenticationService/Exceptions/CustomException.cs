using System;

namespace Module33.AuthenticationService.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
            
        }
    }
}
