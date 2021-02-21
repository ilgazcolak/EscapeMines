using System.IO;
using EscapeMines.Services;

namespace EscapeMines.ConsoleApp
{
	class Program
	{
		static void Main()
		{
			string[] commands = File.ReadAllLines("./commands.txt");
			_ = new GameManager(commands);
		}
	}
}
