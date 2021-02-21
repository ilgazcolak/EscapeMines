using EscapeMines.Core;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models;

namespace EscapeMines.Services
{
	public class ExitService : IExitService
	{
		public Exit Initialize(string[] commandArgs)
		{
			if (commandArgs.Length != 2)
				throw new InvalidArgumentsLengthCountException("InitializeExit() must take 2 arguments.");

			int x = int.Parse(commandArgs[0]);
			int y = int.Parse(commandArgs[1]);

			var exit = new Exit(x, y);

			return exit;
		}
	}
}