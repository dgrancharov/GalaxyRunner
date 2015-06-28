using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy_Runner
{
	public class Map
	{
		Random Rand = new Random();
		private char[,] dataMap;

		public Map (int height, int width, IRenderer renderer)
		{
			this.Height = height;
			this.Width = width;
			this.Renderer = renderer;
			this.dataMap = new char[Height, Width];
		}

		public int Height { get; private set; }
		public int Width { get; private set; }
        public IRenderer Renderer { get; private set; }
        
		public void UpdateMap (IList<GameObject> gameObjects)
		{





			PrintMap (dataMap);
		}

		public void PrintMap (char[,] map)
		{
			for (int row = 0; row < Height; row++) 
			{
				for (int col = 0; col < Width; col++) 
				{
					Renderer.Write (map[row, col]);
				}
				Renderer.WriteLine ();

			}
		}
	}
}

