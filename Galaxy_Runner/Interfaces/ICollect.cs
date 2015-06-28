using System;
using Galaxy_Runner.GameObjects.Items;

namespace Galaxy_Runner.Interfaces
{
	using System.Collections.Generic;

	public interface ICollect
	{
		IEnumerable<Item> Inventory { get; }

		void AddItemToInventory(Item item);
	}
}

