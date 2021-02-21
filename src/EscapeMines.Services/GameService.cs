using System;
using EscapeMines.Core.Enums;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models;
using EscapeMines.Core.Models.Base;
using EscapeMines.Core.Services;

namespace EscapeMines.Services
{
	public class GameService : IGameService
	{
		public Status Status { get; private set; } = Status.StillInDanger;

		public void StartGame(MineField mineField, Turtle turtle, string[] commandArgs)
		{
			foreach (var commandArg in commandArgs)
			{
				_ = Enum.TryParse(commandArg, out Command command);

				switch (command)
				{
					case Command.M:
						turtle.Move();
						break;
					case Command.L:
						turtle.Rotate(Command.L);
						break;
					case Command.R:
						turtle.Rotate(Command.R);
						break;
					case Command.I:
						throw new InvalidCommandException("GameService() Invalid command");
				}

				var coordinate = new Coordinate(turtle.Point.X, turtle.Point.Y);

				Status = mineField.CheckCoordinatesStatus(coordinate);

				if (Status == Status.MineHit)
				{
					Console.WriteLine($"Turtle hits a Mine at {coordinate}.");
					return;
				}
				else if (Status == Status.Success)
				{
					Console.WriteLine($"The turtle reached Exit at {coordinate}.");
					return;
				}

				mineField.ValidateCoordinates(coordinate);
			}
		}
	}
}