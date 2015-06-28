using System;

namespace Galaxy_Runner
{
	public class Obstacle : Item
	{
		public Obstacle (Position position, int size, char obstacleSymbol)
			: base (position, size, obstacleSymbol)
		{
		}

		public override string ToString()
		{
			// ToDo
			return string.Format("Obstacle");
		}
	}
}

