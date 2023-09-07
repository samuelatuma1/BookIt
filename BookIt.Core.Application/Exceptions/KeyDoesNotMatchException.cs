using System;
namespace BookIt.Core.Application.Exceptions
{
	public class KeyDoesNotMatchException : Exception
	{
		
        public IDictionary<string, string> Errors;

        public KeyDoesNotMatchException()
        {
            Errors = new Dictionary<string, string>();
        }
        public KeyDoesNotMatchException(string message) : base(message)
        {
            Errors = new Dictionary<string, string>();
        }

        public KeyDoesNotMatchException(string message, IDictionary<string, string> errors) : base(message)
        {
            Errors = errors;
        }
    }
}

