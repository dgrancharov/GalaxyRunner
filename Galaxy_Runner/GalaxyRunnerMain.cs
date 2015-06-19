using System;

namespace Galaxy_Runner
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to Galaxy Runner!");

			Scooter scooter = new Scooter ("Scooter 1", new Position (0, 0));
			Console.WriteLine (scooter);

			Catamaran catamaran = new Catamaran ("Catamaran 1", new Position (8, 0));
			Console.WriteLine (catamaran);

			BattleCruiser battleCruiser = new BattleCruiser ("BattleCruiser", new Position (16, 0));
			Console.WriteLine (battleCruiser);

			Console.WriteLine ("Game begins ...");
		}
	}
}
