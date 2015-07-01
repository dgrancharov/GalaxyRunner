using System;
using Galaxy_Runner.GameObjects.Items.Obstacles;
using Galaxy_Runner.GameObjects;

namespace Galaxy_Runner.Interfaces
{
	public interface IStarship
	{
		// Optional - when left/right movement is implemented
		// double Fuel { get; set; }

		void Collide(GameObject obstacle);
	}
}

