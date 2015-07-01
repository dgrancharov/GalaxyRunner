using System;
using System.Collections.Generic;
using Galaxy_Runner.Interfaces;
using Galaxy_Runner.GameObjects.Items;
using Galaxy_Runner.GameObjects.Items.Obstacles;

namespace Galaxy_Runner.GameObjects.Ships
{
	public abstract class Starship : GameObject , IStarship, IDestroyable, ICollect, IShoot
	{
        private const int defaultHealth = 150;
        
        private int lives = 3;
        private int health;
       

        private List<Item> inventory;

		protected Starship (Position position)
			: base (position)
		{
			inventory = new List<Item> ();
            this.Health = defaultHealth;
		}

        public int Health
        {
            get { return this.health; }

            set
            {

                this.health = value;
                if (this.Health <= 0)
                {
                    this.Lives--;
                    this.health = defaultHealth;
                }
            }
        }

		public int Lives {
			get 
			{
				return this.lives;
			}
			set 
			{
                this.lives = value;
                if (this.lives == 0)
                {
                    this.Destroy();
                }
			}
		}

		public IEnumerable<Item> Inventory 
		{
			get 
			{
				return this.inventory;
			}
		}

        public void Collide (GameObject obstacle)
        {
            for (int y = this.Position.Y; y < this.ToPrintArray().GetLength(0); y++)
            {
                for (int x = this.Position.X; x < this.ToPrintArray().GetLength(1); x++)
                {
                    if (obstacle.Position.X == x && obstacle.Position.Y == y)
                    {
                        if (obstacle is Obstacle)
                        {
                            this.Health -= 50;
                            obstacle.Destroy();
                        }
                        //TO DO for items and Bonuses
                    }
                }
            }
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

