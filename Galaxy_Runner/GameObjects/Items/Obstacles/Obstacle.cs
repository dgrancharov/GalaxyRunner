using System;

namespace Galaxy_Runner.GameObjects.Items.Obstacles
{
	public abstract class Obstacle : Item
	{
		protected Obstacle (Position position, int size, char obstacleSymbol)
			: base (position, size, obstacleSymbol)
		{
		}

		public override string ToString()
		{
			// ToDo
			return string.Format("Obstacle");
		}


        public abstract override char[,] ToPrintArray();
	}
}

