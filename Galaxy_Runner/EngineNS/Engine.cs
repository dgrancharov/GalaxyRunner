using System;
using System.Linq;
using System.Collections.Generic;

namespace Galaxy_Runner
{
	public class Engine
	{
		public const int height = 30;
		public const int width = 90;

		private static readonly Random Rand = new Random ();

		private readonly IInputReader reader;
		private readonly IRenderer renderer;

		private readonly IList<GameObject> gameObjects;

		public Engine (IInputReader reader, IRenderer renderer)
		{
			this.reader = reader;
			this.renderer = renderer;
			this.gameObjects = new List<GameObject> ();
            this.ObstacleFactory = new ObstacleFactory();
            this.PenaltyFactory = new PenaltyFactory();
            this.BonusFactory = new BonusFactory();
		}

		public bool IsRunning { get; private set; }
        public ObstacleFactory ObstacleFactory { get; private set; }
        public BonusFactory BonusFactory { get; private set; }
        public PenaltyFactory PenaltyFactory { get; private set; }

		public void Run()
		{
			this.IsRunning = true;

			Map gameMap = new Map (height, width, renderer);

			renderer.WriteLine ("Welcome to Galaxy Runner!\n\n");
			
			renderer.WriteLine ("Use the Up and Down keys to play.");
			renderer.WriteLine ("Avoid the rocks!\n\n");

			renderer.WriteLine ("Choose ship type:");
			renderer.WriteLine ("1.Scooter - small and fast");
			renderer.WriteLine ("\t Special function - jump escape");
			renderer.WriteLine ("2.Catamaran - medium sized");
			renderer.WriteLine ("\t Special function - squeeze through");
			renderer.WriteLine ("3.Battlecruiser - big and heavy");
			renderer.WriteLine ("\t Special function - purge everything");

			string choiceOfShip = GetShipType ();

			Starship playerShip = InstantiatePlayerShip (choiceOfShip);

			gameObjects.Add ((GameObject) playerShip);



			while (this.IsRunning) 
			{
				this.IsRunning = true;

				gameMap.UpdateMap (gameObjects);

				this.IsRunning = false;
			}



		}

		public string GetShipType ()
		{
			string choiceOfShip = this.reader.ReadLine ();

			string[] validChoices = { "1", "2", "3" };

			while (!validChoices.Contains (choiceOfShip)) {
				this.renderer.WriteLine ("Invalid choice of shiptype, please re-enter.");
				choiceOfShip = this.reader.ReadLine ();
			}
			return choiceOfShip;

		}
			
		public Starship InstantiatePlayerShip(string choiceOfShip)
		{
			Starship playerShip = null;

			switch(choiceOfShip)
			{
			case "1":
				playerShip = new Scooter (new Position (0, height/2));
				break;
			case "2":
				playerShip = new Catamaran (new Position (0, height/2));
				break;
			case "3":
				playerShip = new BattleCruiser (new Position (0, height/2));
				break;
			}

			return playerShip;
		}
	}
}

