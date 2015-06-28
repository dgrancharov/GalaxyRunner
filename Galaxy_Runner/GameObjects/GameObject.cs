using System;

namespace Galaxy_Runner.GameObjects
{
	public abstract class GameObject
	{
		private Position position;

		public GameObject (Position position)
		{
			this.Position = position;
		}

		public Position Position 
		{
			get 
			{
				return this.position;
			}
			set 
			{
				// validate !

				this.position = value;
			}
		}

        public abstract char[,] ToPrintArray();
	}
}

