using EscapeMines.Core.Enums;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models;
using EscapeMines.Services;
using Xunit;

namespace EscapeMines.Test.GameTests
{
	public class GameServiceTests
	{
		private readonly GameService _gameService;
		private MineField MineField { get; set; }
		private Turtle Turtle { get; set; }

		public GameServiceTests()
		{
			_gameService = new GameService();
			MineField = new MineField(1, 2);
			MineField.ItemCoordinates.Add("[0,2]", new Exit(0, 2));
			MineField.ItemCoordinates.Add("[1,1]", new Mine(1, 1));
			Turtle = new Turtle(0, 0, Direction.N);
		}

		[Theory]
		[InlineData("M", "R", "M")]
		[InlineData("R", "M", "L", "M")]
		public void GameService_MineHit_Succeed(params string[] commandArgs)
		{
			_gameService.StartGame(MineField, Turtle, commandArgs);

			Assert.Equal(Status.MineHit, _gameService.Status);
		}

		[Theory]
		[InlineData("M", "M")]
		[InlineData("L", "R", "M", "M")]
		[InlineData("M", "R", "L", "M")]
		public void GameService_Finish_Succeed(params string[] commandArgs)
		{
			_gameService.StartGame(MineField, Turtle, commandArgs);

			Assert.Equal(Status.Success, _gameService.Status);
		}

		[Theory]
		[InlineData("R")]
		[InlineData("L")]
		[InlineData("M")]
		[InlineData("M", "L")]
		[InlineData("M", "R")]
		public void GameService_StillInDanger_Succeed(params string[] commandArgs)
		{
			_gameService.StartGame(MineField, Turtle, commandArgs);

			Assert.Equal(Status.StillInDanger, _gameService.Status);
		}

		[Theory]
		[InlineData("L", "M")]
		[InlineData("L", "L", "M")]
		[InlineData("R", "M", "M")]
		[InlineData("R", "M", "M", "M")]
		[InlineData("M", "L", "M")]
		[InlineData("M", "R", "R", "R", "M")]
		public void GameService_OutOfBoundaries_Failure(params string[] commandArgs)
		{
			Assert.Throws<OutOfBoundryException>(() => _gameService.StartGame(MineField, Turtle, commandArgs));
		}
	}
}