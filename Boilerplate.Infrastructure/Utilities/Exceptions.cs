using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Infrastructure.Utilities
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException() { }

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
