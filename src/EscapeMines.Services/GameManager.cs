using System;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models;
using EscapeMines.Core.Models.Base;
using EscapeMines.Core.Services;

namespace EscapeMines.Services
{
	public class GameManager : IGameManager
	{
		private readonly GameService _gameService;
		private readonly MineFieldService _mineFieldService;
		private readonly TurtleService _turtleService;
		private readonly MineService _mineService;
		private readonly ExitService _exitService;
		private string[] Commands { get; set; }
		private MineField MineField { get; set; }
		private Turtle Turtle { get; set; }

		public GameManager(string[] commands)
		{
			Commands = commands;

			_gameService = new GameService();
			_mineFieldService = new MineFieldService();
			_turtleService = new TurtleService();
			_mineService = new MineService();
			_exitService = new ExitService();

			Initialize();
		}
		public void Initialize()
		{
			try
			{
				if (Commands.Length < 5)
					throw new InvalidCommandsLengthException("Commands length must be greater than or equal to 5.");

				for (int i = 0; i < 4; i++)
				{
					ApplyCommand(i, Commands[i]);
				}

				string seriesOfMoves = null;
				for (int i = 4; i < Commands.Length; i++)
				{
					seriesOfMoves += $" {Commands[i]}";
				}
				ApplyCommand(4, seriesOfMoves.Trim());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		#region Private Methods
		private void ApplyCommand(int commandOrder, string command)
		{
			string[] commandArgs = command.Split(' ');
			switch (commandOrder)
			{
				case 0: // Initialize MineField
					MineField = _mineFieldService.Initialize(commandArgs);
					break;
				case 1: // Initialize Mines
					_mineService.Initialize(commandArgs).ForEach(x =>
					{
						MineField.ValidateCoordinates(new Coordinate(x.X, x.Y));
						MineField.SetItemCoordinates(new Coordinate(x.X, x.Y), x);
					});
					break;
				case 2: // Initialize Exit
					var mine = _exitService.Initialize(commandArgs);
					MineField.ValidateCoordinates(new Coordinate(mine.X, mine.Y));
					MineField.SetItemCoordinates(new Coordinate(mine.X, mine.Y), mine);
					break;
				case 3: // Initialize Turtle
					Turtle = _turtleService.Initialize(commandArgs);
					MineField.ValidateCoordinates(new Coordinate(Turtle.Point.X, Turtle.Point.Y));
					break;
				case 4: // Series of Move - Rotate Actions
					_gameService.StartGame(MineField, Turtle, commandArgs);
					break;
			}
		}

		#endregion Private Methods
	}
}