using System;

namespace Module33.AuthenticationService.BLL.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
