using System;

namespace Galaxy_Runner.GameObjects.Items.Bonuses
{
	public abstract class Bonus : Item
	{
		private const int BonusSize = 1;

		public Bonus (Position position, int size, char bonusSymbol)
			: base (position, BonusSize, bonusSymbol)
		{
			
		}

        public abstract override void UpdatePosition();
        public abstract override char[,] ToPrintArray();
	}
}

