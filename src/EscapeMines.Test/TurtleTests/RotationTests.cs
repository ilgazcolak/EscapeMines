using EscapeMines.Core.Enums;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models;
using Xunit;

namespace EscapeMines.Test.TurtleTests
{
	public class RotationTests
	{
		[Theory]
		[InlineData(Direction.N, Command.R, Direction.E)]
		[InlineData(Direction.E, Command.R, Direction.S)]
		[InlineData(Direction.S, Command.R, Direction.W)]
		[InlineData(Direction.W, Command.R, Direction.N)]
		[InlineData(Direction.N, Command.L, Direction.W)]
		[InlineData(Direction.W, Command.L, Direction.S)]
		[InlineData(Direction.S, Command.L, Direction.E)]
		[InlineData(Direction.E, Command.L, Direction.N)]
		public void Turtle_Rotate_ValidCommand_Success(Direction direction, Command command, Direction expectedDirection)
		{
			var turtle = new Turtle(0, 0, direction);

			turtle.Rotate(command);

			Assert.Equal(turtle.Direction, expectedDirection);
		}

		[Theory]
		[InlineData(Direction.N, Command.M)]
		[InlineData(Direction.E, Command.M)]
		[InlineData(Direction.S, Command.M)]
		[InlineData(Direction.W, Command.M)]
		public void Turtle_Rotate_InvalidCommand_Failure(Direction direction, Command command)
		{
			var turtle = new Turtle(0, 0, direction);

			Assert.Throws<InvalidCommandException>(() => turtle.Rotate(command));
		}
	}
}