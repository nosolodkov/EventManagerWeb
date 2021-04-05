using System;
using System.Collections.Generic;
using System.Text;

namespace EventServices.Exceptions
{
    public class MaxGuestsForEventException : Exception
    {
        public MaxGuestsForEventException(string? message) : base(message)
        {

        }
    }
}
