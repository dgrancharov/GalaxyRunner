using System;
using System.Collections.Generic;

namespace Galaxy_Runner
{
	public abstract class Starship : GameObject , IStarship, IDestroyable, ICollect, IShoot
	{
		private int lives = 3;
		private List<Item> inventory;

		protected Starship (Position position)
			: base (position)
		{
			inventory = new List<Item> ();
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

        public abstract override char[,] ToPrintArray();
	
	}
}

