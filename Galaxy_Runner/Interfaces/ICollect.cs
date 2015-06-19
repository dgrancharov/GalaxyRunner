using System;

namespace Galaxy_Runner
{
	using System.Collections.Generic;

	public interface ICollect
	{
		IEnumerable<Item> Inventory { get; }

		void AddItemToInventory(Item item);
	}
}

