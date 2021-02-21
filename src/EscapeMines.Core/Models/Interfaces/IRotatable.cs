using EscapeMines.Core.Enums;

namespace EscapeMines.Core.Models.Interfaces
{
	public interface IRotatable
	{
		void Rotate(Command command);
	}
}