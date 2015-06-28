using System;

namespace Galaxy_Runner
{
	public abstract class Bonus : Item
	{
		private const int BonusSize = 1;

		public Bonus (Position position, int size, char bonusSymbol)
			: base (position, BonusSize, bonusSymbol)
		{
			
		}
	}
}

