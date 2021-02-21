using System;
using EscapeMines.Core.Enums;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models;
using EscapeMines.Core.Services;

namespace EscapeMines.Services
{
	public class TurtleService : ITurtleService
	{
		public Turtle Initialize(string[] commandArgs)
		{
			if (commandArgs.Length != 3)
				throw new InvalidArgumentsLengthCountException("InitializeTurtle() must take 3 arguments.");

			int x = int.Parse(commandArgs[0]);
			int y = int.Parse(commandArgs[1]);
			_ = Enum.TryParse(commandArgs[2], out Direction direction);

			return new Turtle(x, y, direction);
		}
	}
}