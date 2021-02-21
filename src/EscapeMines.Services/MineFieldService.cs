using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models;
using EscapeMines.Core.Services;

namespace EscapeMines.Services
{
	public class MineFieldService : IMineFieldService
	{
		public MineField Initialize(string[] commandArgs)
		{
			if (commandArgs.Length != 2)
				throw new InvalidArgumentsLengthCountException("InitializeBoard() must take 2 arguments.");

			int x = int.Parse(commandArgs[0]);
			int y = int.Parse(commandArgs[1]);

			return new MineField(x, y);
		}
	}
}