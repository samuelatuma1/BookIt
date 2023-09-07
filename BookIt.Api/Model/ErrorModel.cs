using System;
namespace BookIt.Api.Model
{
	public class ErrorModel
	{
		public string Message { get; set; } = string.Empty;
        public IDictionary<string, string> Errors = new Dictionary<string, string>();
    }
}

