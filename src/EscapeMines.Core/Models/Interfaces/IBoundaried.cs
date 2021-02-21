using EscapeMines.Core.Enums;
using EscapeMines.Core.Models.Base;

namespace EscapeMines.Core.Models.Interfaces
{
	public interface IBoundaried
	{
		void SetItemCoordinates(Coordinate coordinate, Stationary stationary);
		Status CheckCoordinatesStatus(Coordinate coordinate);
		void ValidateCoordinates(Coordinate coordinate);
	}
}