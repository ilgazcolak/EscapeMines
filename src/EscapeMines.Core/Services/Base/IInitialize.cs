namespace EscapeMines.Core.Services.Base
{
	public interface IInitialize
	{
		void Initialize();
	}

	public interface IInitialize<T> where T : class
	{
		T Initialize(string[] commandArgs);
	}
}