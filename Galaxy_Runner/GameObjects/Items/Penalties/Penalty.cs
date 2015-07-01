using System;

namespace Galaxy_Runner.GameObjects.Items.Penalties
{
	public abstract class Penalty : Item
	{
		private const int PenaltySize = 1;

		public Penalty (Position position, int size, char penaltySymbol)
			: base (position, PenaltySize, penaltySymbol)
		{
		}

        public abstract override char[,] ToPrintArray();
	}
}

