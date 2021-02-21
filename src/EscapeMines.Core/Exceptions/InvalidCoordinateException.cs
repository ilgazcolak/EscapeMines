using System;

namespace EscapeMines.Core.Exceptions
{
	public class InvalidCoordinateException : Exception
	{
		public InvalidCoordinateException(string message) : base(message)
		{ }
	}
}