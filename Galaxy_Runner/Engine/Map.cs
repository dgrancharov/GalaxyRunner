using System;
using Galaxy_Runner.Engine;

namespace Galaxy_Runner
{
	public class Map
	{
		public Map (int height, int width)
		{
			this.Height = height;
			this.Width = width;
		}

		public int Height { get; private set; }
		public int Width { get; private set; }

//		public void CreateMap()
//		{
//			throw new NotImplementedException ();
//		}

		public void PrintMap ()
		{
			for (int row = 0; row < Height; row++) 
			{
				for (int col = 0; col < Width; col++) 
				{
					renderer.Write (" ");
				}
				renderer.WriteLine ();
			}
			throw new NotImplementedException();

		}
	}
}

