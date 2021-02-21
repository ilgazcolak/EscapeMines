using System;

namespace EscapeMines.Core.Exceptions
{
	public class InvalidCommandsFormatException : Exception
	{
		public InvalidCommandsFormatException(string message) : base(message)
		{ }
	}
}