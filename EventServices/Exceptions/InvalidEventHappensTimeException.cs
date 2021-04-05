using System;
using System.Collections.Generic;
using System.Text;

namespace EventServices.Exceptions
{
    public class InvalidEventHappensTimeException : Exception
    {
        public InvalidEventHappensTimeException(string? message) : base(message)
        {

        }
    }
}
