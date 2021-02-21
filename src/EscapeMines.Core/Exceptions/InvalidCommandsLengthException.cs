using System;

namespace EscapeMines.Core.Exceptions
{
	public class InvalidCommandsLengthException : Exception
	{
		public InvalidCommandsLengthException(string message) : base(message)
		{ }
	}
}