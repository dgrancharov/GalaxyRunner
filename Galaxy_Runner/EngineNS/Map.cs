using System;

namespace Galaxy_Runner
{
	public class Map
	{
		public Map (int height, int width, IRenderer renderer)
		{
			this.Height = height;
			this.Width = width;
			this.Renderer = renderer;
		}

		public int Height { get; private set; }
		public int Width { get; private set; }
		public IRenderer Renderer { get; }

		public void PrintMap ()
		{
			

			for (int row = 0; row < Height; row++) 
			{
				for (int col = 0; col < Width; col++) 
				{
					Renderer.Write ("&");
				}
				Renderer.WriteLine ();

			}
			Renderer.WriteLine ("Height = {0}, Width = {1}", Height, Width);

		}
	}
}

