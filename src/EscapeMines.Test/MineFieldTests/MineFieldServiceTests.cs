using EscapeMines.Core.Exceptions;
using EscapeMines.Services;
using Xunit;

namespace EscapeMines.Test.MineFieldTests
{
	public class MineFieldServiceTests
	{
		private readonly MineFieldService _mineFieldService;

		public MineFieldServiceTests()
		{
			_mineFieldService = new MineFieldService();
		}

		[Theory]
		[InlineData("1")]
		[InlineData("1", "2", "3")]
		[InlineData("1", "2", "3", "4")]
		public void MineField_Initialize_InvalidCommands_Failure(params string[] commandArgs)
		{
			Assert.Throws<InvalidArgumentsLengthCountException>(() => _mineFieldService.Initialize(commandArgs));
		}
	}
}