using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string> Errors;

        public BadRequestException()
        {
            Errors = new Dictionary<string, string>();
        }
        public BadRequestException(string message)  : base(message)
        {
            Errors = new Dictionary<string, string>();
        }

        public BadRequestException(string message, IDictionary<string, string> errors) : base(message) 
        {
            Errors = errors;
        }
    }
}
