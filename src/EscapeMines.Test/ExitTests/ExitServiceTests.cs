using EscapeMines.Core.Exceptions;
using EscapeMines.Services;
using Xunit;

namespace EscapeMines.Test.ExitTests
{
	public class ExitServiceTests
	{
		private readonly ExitService _exitService;
		public ExitServiceTests()
		{
			_exitService = new ExitService();
		}

		[Theory]
		[InlineData("1")]
		[InlineData("1", "2", "3")]
		[InlineData("1", "2", "3", "4")]
		public void ExitService_Initialize_InvalidCommands_Failure(params string[] commandArgs)
		{
			Assert.Throws<InvalidArgumentsLengthCountException>(() => _exitService.Initialize(commandArgs));
		}
	}
}