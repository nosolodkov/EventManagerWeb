using System;
using System.Collections.Generic;
using System.Text;

namespace EventServices.Exceptions
{
    public class GuestIsAlreadyExistsException : Exception
    {
        public GuestIsAlreadyExistsException(string? message) : base(message)
        {

        }
    }
}
