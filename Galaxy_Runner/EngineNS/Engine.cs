using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Galaxy_Runner.Interfaces;
using Galaxy_Runner.GameObjects;
using Galaxy_Runner.EngineNS.Factories;
using Galaxy_Runner.GameObjects.Ships;
using Galaxy_Runner.EngineNS.Commands;
using Galaxy_Runner.GameObjects.Items;

namespace Galaxy_Runner.EngineNS
{
	public class Engine
	{
		public const int height = 33;
		public const int width = 150;
        public const int reducedWidth = 120;
        public const int obstacleMaxSize = 7;
        
        private bool isPause = false;

		private static readonly Random Rand = new Random ();

		private readonly IInputReader reader;
		private readonly IRenderer renderer;

		private readonly IList<GameObject> gameObjects;

		public Engine (IInputReader reader, IRenderer renderer)
		{
			this.reader = reader;
            this.AtachReaderEvents();
			this.renderer = renderer;
			this.gameObjects = new List<GameObject> ();
            this.ObstacleFactory = new ObstacleFactory();
            this.PenaltyFactory = new PenaltyFactory();
            this.BonusFactory = new BonusFactory();
            this.Score = 0;
            this.Level = 1;
            this.Iterations = 1;
		}

        private int Iterations { get; set; }
		public bool IsRunning { get; private set; }
        public ObstacleFactory ObstacleFactory { get; private set; }
        public BonusFactory BonusFactory { get; private set; }
        public PenaltyFactory PenaltyFactory { get; private set; }
        public int Score { get; set; }
        public int Level { get; set; }

        private void AtachReaderEvents()
        {
            this.reader.KeyPress += EventControler;
        }

        private void EventControler(object sender, ProcessEventArgs data)
        {
            switch (data.KeyPressed)
            {
                case ConsoleKey.LeftArrow:
                    {
                        //TODO
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        //TODO
                    }
                    break;
                case ConsoleKey.Spacebar:
                    {
                        this.isPause = !this.isPause;
                    }
                    break;
            }
        }

		public void Run()
		{
			this.IsRunning = true;

			Map gameMap = new Map (height, width, reducedWidth, renderer);

			this.renderer.WriteLine ("White","Welcome to Galaxy Runner!\n\n");

            this.renderer.WriteLine ("White", "Use the Up and Down keys to play.");
            this.renderer.WriteLine ("White", "Avoid the rocks!\n\n");

            this.renderer.WriteLine ("White", "Choose ship type:");
            this.renderer.WriteLine ("White", "1.Scooter - small and fast");
            this.renderer.WriteLine ("White", "\t Special function - jump escape");
            this.renderer.WriteLine ("White", "2.Catamaran - medium sized");
            this.renderer.WriteLine ("White", "\t Special function - squeeze through");
            this.renderer.WriteLine ("White", "3.Battlecruiser - big and heavy");
            this.renderer.WriteLine ("White", "\t Special function - purge everything");

			string choiceOfShip = GetShipType ();

			Starship playerShip = InstantiatePlayerShip (choiceOfShip);

			gameObjects.Add ((GameObject) playerShip);

            CreateObstacles(Level);

            gameMap.PopulateMap(playerShip, gameObjects);

            while (this.IsRunning)
             {
                this.IsRunning = true;
                if (!isPause)
                {
                    foreach (GameObject go in gameObjects)
                    {
                        if (go is Item)
                        {
                            go.UpdatePosition();
                        }
                    }
                    gameMap.UpdateMap(playerShip);
                }
                this.reader.IsKeyPressed();
                
                if(this.Iterations % (width - reducedWidth) == 0)
                {
                    this.Level++;
                    CreateObstacles(Level);
                    gameMap.PopulateMap(playerShip, gameObjects);
                }

                Collision(playerShip, gameObjects);
                CheckDestroyedGameObjects(gameObjects);

                this.Score += 3;
                this.Iterations++;
            }



		}

		public string GetShipType ()
		{
			string choiceOfShip = this.reader.ReadLine ();

			string[] validChoices = { "1", "2", "3" };

			while (!validChoices.Contains (choiceOfShip)) {
                this.renderer.WriteLine("White", "Invalid choice of shiptype, please re-enter.");
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
				playerShip = new Scooter (new Position (2, height/2 - 2));
				break;
			case "2":
				playerShip = new Catamaran (new Position (2, height/2 - 2));
				break;
			case "3":
				playerShip = new BattleCruiser (new Position (2, height/2 - 2));
				break;
			}

			return playerShip;
		}
        
        public void CreateObstacles(int Level)
        {
            for (int i = 0; i< 10; i++)
            {
                IItem newObstacle = this.ObstacleFactory.CreateObstacle(GetRandomPosition(Level), Level, Rand);
                gameObjects.Add((GameObject) newObstacle);
            }
        }

        public Position GetRandomPosition(int Level)
        {
            int x = GetRandomX(Level);
            int y = GetRandomY(Level);
            Position newPosition = new Position(x, y);

            return newPosition;
        }
        
        public static int GetRandomX(int Level)
        {
            int tmpRandomx;
            if(Level < obstacleMaxSize )
            {
                tmpRandomx = Rand.Next(reducedWidth, width - Level);
            }
            else
            {
                tmpRandomx = Rand.Next(reducedWidth, width - obstacleMaxSize);
            }
            return tmpRandomx;
        }
       
        public static int GetRandomY(int Level)
        {
            int tmpRandomY;
            if (Level < obstacleMaxSize)
            {
                tmpRandomY = Rand.Next(0, height - Level);
            }
            else
            {
                tmpRandomY = Rand.Next(0, height - obstacleMaxSize);
            }
            return tmpRandomY;
        }

        public void Collision(Starship ship, IList<GameObject> gameObjects)
        {

            foreach (var obstacle in gameObjects)
            {
                if (!(obstacle is Starship))
                {
                    ship.Collide(obstacle);
                }

            }
        }

        public void CheckDestroyedGameObjects(IList<GameObject> gameObjects)
        {
            foreach (var item in gameObjects)
            {
                if (item.IsDestroyed)
                {
                    gameObjects.Remove(item);
                }
            }
        }
	}
}

