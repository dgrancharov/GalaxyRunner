using System;

namespace Galaxy_Runner
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IInputReader reader = new ConsoleInputReader ();
			IRenderer renderer = new ConsoleRenderer ();

			Engine engine = new Engine (reader, renderer);

			engine.Run ();

//			Scooter scooter = new Scooter ("Scooter 1", new Position (0));
//			Console.WriteLine (scooter);
//
//			Catamaran catamaran = new Catamaran ("Catamaran 1", new Position (8));
//			Console.WriteLine (catamaran);
//
//			BattleCruiser battleCruiser = new BattleCruiser ("BattleCruiser", new Position (16));
//			Console.WriteLine (battleCruiser);
//
//			Console.WriteLine ("Game begins ...");
		}
	}
}
