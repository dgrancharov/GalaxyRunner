using System;

namespace Galaxy_Runner
{
	public class Bonuses : Item
	{
		private const int BonusSize = 1;

		public Bonuses (Position position, int size, char bonusSymbol)
			: base (position, BonusSize, BonusSymbol)
		{
			
		}

		public override string ToString ()
		{
			// ToDo
			return string.Format ("[Bonuses]");
		}
	}
}

