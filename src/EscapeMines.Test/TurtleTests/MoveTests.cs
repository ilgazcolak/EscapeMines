using EscapeMines.Core.Enums;
using EscapeMines.Core.Models;
using Xunit;

namespace EscapeMines.Test.TurtleTests
{
	public class MoveTests
	{
		[Theory]
		[InlineData(1, 1)]
		public void Turtle_Move_North_Success(int x, int y)
		{
			var turtle = new Turtle(x, y, Direction.N);

			turtle.Move();

			Assert.Equal(y + 1, turtle.Point.Y);
		}

		[Theory]
		[InlineData(1, 1)]
		public void Turtle_Move_East_Success(int x, int y)
		{
			var turtle = new Turtle(x, y, Direction.E);

			turtle.Move();

			Assert.Equal(x + 1, turtle.Point.X);
		}

		[Theory]
		[InlineData(1, 1)]
		public void Turtle_Move_South_Success(int x, int y)
		{
			var turtle = new Turtle(x, y, Direction.S);

			turtle.Move();

			Assert.Equal(y - 1, turtle.Point.Y);
		}

		[Theory]
		[InlineData(1, 1)]
		public void Turtle_Move_West_Success(int x, int y)
		{
			var turtle = new Turtle(x, y, Direction.W);

			turtle.Move();

			Assert.Equal(x - 1, turtle.Point.X);
		}
	}
}