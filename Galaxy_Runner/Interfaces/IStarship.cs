using System;

namespace Galaxy_Runner
{
	public interface IStarship
	{
		// Optional - when left/right movement is implemented
		// double Fuel { get; set; }

		void Collide(Obstacle obstacle);

		string ToString ();
	}
}

