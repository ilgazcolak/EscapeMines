using EscapeMines.Core.Models;

namespace EscapeMines.Core.Services
{
	public interface IGameService
	{
		void StartGame(MineField mineField, Turtle turtle, string[] commandArgs);
	}
}