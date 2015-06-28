using System;
using Galaxy_Runner.GameObjects.Items.Obstacles;

namespace Galaxy_Runner.Interfaces
{
	public interface IStarship
	{
		// Optional - when left/right movement is implemented
		// double Fuel { get; set; }

		void Collide(Obstacle obstacle);
	}
}

