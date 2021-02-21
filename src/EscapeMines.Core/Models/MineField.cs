using System.Collections.Generic;
using EscapeMines.Core.Constants;
using EscapeMines.Core.Enums;
using EscapeMines.Core.Exceptions;
using EscapeMines.Core.Models.Base;
using EscapeMines.Core.Models.Interfaces;

namespace EscapeMines.Core.Models
{
	public class MineField : Coordinate, IBoundaried
	{
		public Dictionary<string, Stationary> ItemCoordinates { get; private set; }
		public MineField(int x, int y) : base(x, y)
		{
			ItemCoordinates = new Dictionary<string, Stationary>();
		}

		public void SetItemCoordinates(Coordinate coordinate, Stationary stationary)
		{
			if (ItemCoordinates.GetValueOrDefault(coordinate.ToString(), null) != null)
				return;
			ItemCoordinates.Add(coordinate.ToString(), stationary);
		}

		public Status CheckCoordinatesStatus(Coordinate coordinate)
		{
			ItemCoordinates.TryGetValue(coordinate.ToString(), out Stationary stationary);

			if (stationary == null)
				return Status.StillInDanger;
			var type = stationary.GetType().Name;

			return type switch
			{
				StationaryName.MINE => Status.MineHit,
				StationaryName.EXIT => Status.Success,
				_ => Status.StillInDanger,
			};
		}

		public void ValidateCoordinates(Coordinate coordinate)
		{
			if (!AreBoundariesValid(coordinate))
				throw new OutOfBoundryException($"The coordinates {coordinate} must be inside boundaries [{X},{Y}].");

			CheckCoordinatesAvailability(coordinate);
			return;
		}

		#region Private Methods
		private bool AreBoundariesValid(Coordinate coordinate)
		{
			bool isValid =
						X >= coordinate.X
						&& coordinate.X >= 0
						&& Y >= coordinate.Y
						&& coordinate.Y >= 0;
			return isValid;
		}
		public void CheckCoordinatesAvailability(Coordinate coordinate)
		{
			ItemCoordinates.TryGetValue(coordinate.ToString(), out Stationary stationary);
			if (stationary != null)
				throw new InvalidCoordinateException($"The coordinate {coordinate} already occupied by {stationary.GetType().Name}.");
			return;
		}
		#endregion Private Methods
	}
}