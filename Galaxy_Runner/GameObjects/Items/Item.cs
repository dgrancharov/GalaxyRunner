using System;

namespace Galaxy_Runner
{
	public abstract class Item : GameObject, IItem
	{
		protected Item (Position position, int size, char itemSymbol)
			: base (position)
		{
			this.Size = size;
			this.ItemSymbol = itemSymbol;
		}

		public int Size { get; set; }
		public char ItemSymbol { get; set; }

		public abstract override string ToString();
	}
}

