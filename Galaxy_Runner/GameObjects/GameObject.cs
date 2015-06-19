using System;

namespace Galaxy_Runner
{
	public class GameObject
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
	}
}

