using System;
using Galaxy_Runner.Interfaces;

namespace Galaxy_Runner.GameObjects.Items
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

        public abstract override void UpdatePosition();
        public abstract override char[,] ToPrintArray();
	}
}

