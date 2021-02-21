using System;

namespace EscapeMines.Core.Exceptions
{
	public class InvalidCommandException : Exception
	{
		public InvalidCommandException(string message) : base(message)
		{ }
	}
}