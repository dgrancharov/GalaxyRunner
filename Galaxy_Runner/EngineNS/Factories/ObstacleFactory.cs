using System;
using Galaxy_Runner.GameObjects.Items.Obstacles;
using Galaxy_Runner.Interfaces;

namespace Galaxy_Runner.EngineNS.Factories
{
	
	public class ObstacleFactory
	{
		Random rnd = new Random();

		public ObstacleFactory ()
		{
		}

		public IItem CreateObstacle(Position position, int size)
		{
			char symbol;
			int randNumber = rnd.Next(4);

			switch (randNumber) 
			{
			case 0:
				symbol = '@';
				break;
			case 1:
				symbol = '*';
				break;
			case 2:
				symbol = '&';
				break;
			case 3:
				symbol = '#';
				break;
			default:
				throw new IndexOutOfRangeException ();
			}
			
			return new SquareObstacle (position, size, symbol);
		}
	}
}

