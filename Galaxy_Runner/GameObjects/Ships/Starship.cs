using System;
using System.Collections.Generic;

namespace Galaxy_Runner
{
	public abstract class Starship : GameObject , IStarship, IDestroyable, ICollect, IShoot
	{
		private string name;
		private int lives = 3;
		private List<Item> inventory;

		protected Starship (string name, Position position)
			: base (position)
		{
			this.Name = name;
			inventory = new List<Item> ();
		}

		public string Name {
			get 
			{
				return this.name;
			}
			set 
			{
				// validate
				this.name = value;
			}
		}

		public int Lives {
			get 
			{
				return this.lives;
			}
			set 
			{
				// validate
				this.lives = value;
			}
		}

		public IEnumerable<Item> Inventory 
		{
			get 
			{
				return this.inventory;
			}
		}

		public void Collide (Obstacle obstacle)
		{
			throw new NotImplementedException ();
		}
			
		public void AddItemToInventory (Item item)
		{
			throw new NotImplementedException ();
		}
			
		public void Shoot (char bulletType, int bulletCount)
		{
			throw new NotImplementedException ();
		}

		public override abstract string ToString();
	}
}

