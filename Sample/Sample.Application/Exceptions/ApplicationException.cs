using System;
using System;

namespace Sample.Application.Exceptions
{
    public class ApplicationException: Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }
}
