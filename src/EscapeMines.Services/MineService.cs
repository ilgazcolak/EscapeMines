using System.Collections.Generic;
using EscapeMines.Core;
using EscapeMines.Core.Models;

namespace EscapeMines.Services
{
	public class MineService : IMineService
	{
		public List<Mine> Initialize(string[] commandArgs)
		{
			var mines = new List<Mine>();

			foreach (var commandArg in commandArgs)
			{
				int x = int.Parse(commandArg.Split(',')[0]);
				int y = int.Parse(commandArg.Split(',')[1]);

				var mine = new Mine(x, y);

				mines.Add(mine);
			}

			return mines;
		}
	}
}