using EscapeMines.Core.Enums;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models.Interfaces;

namespace EscapeMines.Core.Models.Base
{
	public abstract class Character : IMovable, IRotatable
	{
		public Direction Direction { get; protected set; }
		public Point Point { get; protected set; }

		public Character(int x, int y, Direction direction)
		{
			Direction = direction;
			Point = new Point(x, y);
		}

		public void Move()
		{
			switch (Direction)
			{
				case Direction.N:
					Point = new Point(Point.X, Point.Y + 1);
					break;
				case Direction.E:
					Point = new Point(Point.X + 1, Point.Y);
					break;
				case Direction.S:
					Point = new Point(Point.X, Point.Y - 1);
					break;
				case Direction.W:
					Point = new Point(Point.X - 1, Point.Y);
					break;
			}
		}

		public void Rotate(Command command)
		{
			switch (command)
			{
				case Command.L:
					if (Direction == Direction.N)
						Direction = Direction.W;
					else if (Direction == Direction.E)
						Direction = Direction.N;
					else if (Direction == Direction.S)
						Direction = Direction.E;
					else if (Direction == Direction.W)
						Direction = Direction.S;
					break;
				case Command.R:
					if (Direction == Direction.N)
						Direction = Direction.E;
					else if (Direction == Direction.E)
						Direction = Direction.S;
					else if (Direction == Direction.S)
						Direction = Direction.W;
					else if (Direction == Direction.W)
						Direction = Direction.N;
					break;
				default:
					throw new InvalidCommandException("Rotate() Invalid Command Exception");
			}
		}
	}
}