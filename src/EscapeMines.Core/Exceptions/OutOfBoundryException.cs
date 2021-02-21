using System;

namespace EscapeMines.Core.Exceptions
{
	public class OutOfBoundryException : Exception
	{
		public OutOfBoundryException(string message) : base(message)
		{ }
	}
}