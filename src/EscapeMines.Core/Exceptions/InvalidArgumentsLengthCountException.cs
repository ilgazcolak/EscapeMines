using System;

namespace EscapeMines.Core.Exceptions
{
	public class InvalidArgumentsLengthCountException : Exception
	{
		public InvalidArgumentsLengthCountException(string message) : base(message)
		{ }
	}
}