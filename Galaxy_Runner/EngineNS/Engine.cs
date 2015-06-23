using System;

namespace Galaxy_Runner
{
	public class Engine
	{
		public const int windowHeight = 30;
		public const int windowWidth = 90;

		private static readonly Random Rand = new Random ();

		private readonly IInputReader reader;
		private readonly IRenderer renderer;

		public Engine (IInputReader reader, IRenderer renderer)
		{
			this.reader = reader;
			this.renderer = renderer;
		}

		public void Run()
		{
			Map gameMap = new Map (windowHeight, windowWidth, renderer);

			gameMap.PrintMap ();

			renderer.Write ("Game has started...");
		}
	}
}

