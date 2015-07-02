using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Galaxy_Runner.Interfaces;
using Galaxy_Runner.GameObjects;
using Galaxy_Runner.EngineNS.Factories;
using Galaxy_Runner.GameObjects.Ships;
using Galaxy_Runner.EngineNS.Commands;
using Galaxy_Runner.GameObjects.Items;
using Galaxy_Runner.GameObjects.Items.Projectiles;
using Galaxy_Runner.GameObjects.Items.Obstacles;

namespace Galaxy_Runner.EngineNS
{
	public class Engine
	{
		public const int height = 33;
		public const int width = 120;
        public const int reducedWidth = 100;
        public const int obstacleMaxSize = 7;
        
        private bool isPause = false;

		private static readonly Random Rand = new Random ();

		private readonly IInputReader reader;
		private readonly IRenderer renderer;

		private readonly IList<GameObject> gameObjects;
        private readonly IList<Projectile> projectilesOnMap;

		public Engine (IInputReader reader, IRenderer renderer)
		{
			this.reader = reader;
            this.AtachReaderEvents();
			this.renderer = renderer;
			this.gameObjects = new List<GameObject> ();
            this.projectilesOnMap = new List<Projectile>();
            this.ObstacleFactory = new ObstacleFactory();
            this.PenaltyFactory = new PenaltyFactory();
            this.BonusFactory = new BonusFactory();
            this.Score = 0;
            this.Level = 1;
            this.Iterations = 1;
            this.Difficulty = "Low";
            this.ThreadSleepConst = 350;
		}

        private int Iterations { get; set; }
		public bool IsRunning { get; private set; }
        public ObstacleFactory ObstacleFactory { get; private set; }
        public BonusFactory BonusFactory { get; private set; }
        public PenaltyFactory PenaltyFactory { get; private set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public string Difficulty { get; set; }
        public int ThreadSleepConst { get; set; }

        private void AtachReaderEvents()
        {
            this.reader.KeyPress += EventController;
        }

        private void EventController(object sender, ProcessEventArgs data)
        {
            switch (data.KeyPressed)
            {
                case ConsoleKey.UpArrow:
                    {
                        MoveShipUp();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        MoveShipDown();
                    }
                    break;
                case ConsoleKey.P:
                    {
                        this.isPause = !this.isPause;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    {
                        Shoot();
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

            this.renderer.WriteLine ("White", "Choose difficulty:");
            this.renderer.WriteLine ("White", "\t Low, Medium, High");

            GetDifficulty ();

            this.renderer.Clear();

			Starship playerShip = InstantiatePlayerShip (choiceOfShip);
            
            this.ThreadSleepConst = SetDifficulty(this.Difficulty);

			gameObjects.Add ((GameObject) playerShip);
            
            CreateObstacles(Level);

            while (this.IsRunning)
             {
                this.IsRunning = true;
                if (!isPause)
                {
                    if (this.gameObjects.Where(go => go is Projectile).Count() > 0)
                    {
                        DestroyObstacles();
                    }

                    foreach (GameObject go in gameObjects)
                    {
                        if (!(go is Starship))
                        {
                            CheckPassedGameObjects(gameObjects);
                            go.UpdatePosition();
                        }
                    }
                    gameMap.UpdateMap(playerShip, gameObjects);
                    
                    if (this.Iterations % (width - reducedWidth) == 0)
                    {
                        this.Level++;
                        CreateObstacles(Level);
                    }

                    Collision(playerShip, gameObjects);
                    CheckDestroyedGameObjects(gameObjects);

                    this.Score += 3;
                    this.Iterations++;
                    this.CheckShipLives(playerShip);

                    if ((this.ThreadSleepConst - Level * 50) > 0)
                    {
                        Thread.Sleep(this.ThreadSleepConst - Level * 50);
                    }
                }
                this.reader.IsKeyPressed();
            }
            this.renderer.WriteLine("White", "Game Over!");
            this.renderer.WriteLine("White", "Your score: {0}", this.Score);
		}

        public string GetShipType()
        {
            string choiceOfShip = this.reader.ReadLine();

            string[] validChoices = { "1", "2", "3" };

            while (!validChoices.Contains(choiceOfShip))
            {
                this.renderer.WriteLine("White", "Invalid choice of shiptype, please re-enter.");
                choiceOfShip = this.reader.ReadLine();
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

        public void GetDifficulty()
        {
            string choiceOfDifficulty = this.reader.ReadLine();

            string[] validChoices = { "Low", "Medium", "High" };

            if (validChoices.Contains(choiceOfDifficulty))
            {
                this.renderer.WriteLine("White", "Invalid choice of difficulty, please re-enter.");
                this.Difficulty = choiceOfDifficulty;
            }
            else
            {
                this.Difficulty = "Low";
            }
        }
        
        public int SetDifficulty (string difficulty)
        {
            int tmpDiff = 0;
            switch(difficulty)
            {
                case "Low":
                    tmpDiff = 350;
                    break;
                case "Medium":
                    tmpDiff = 250;
                    break;
                case "High":
                    tmpDiff = 150;
                    break;
            }
            return tmpDiff;
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
                tmpRandomx = Rand.Next(reducedWidth, width - Level - 1);
            }
            else
            {
                tmpRandomx = Rand.Next(reducedWidth, width - obstacleMaxSize - 1);
            }
            return tmpRandomx;
        }
       
        public static int GetRandomY(int Level)
        {
            int tmpRandomY;
            if (Level < obstacleMaxSize)
            {
                tmpRandomY = Rand.Next(0, height - Level - 1);
            }
            else
            {
                tmpRandomY = Rand.Next(0, height - obstacleMaxSize - 1);
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
            for (int i = 0; i < this.gameObjects.Count; i++)
            {
                if (this.gameObjects[i].IsDestroyed)
                {
                    gameObjects.Remove(this.gameObjects[i]);
                }
            }
        }

        public void CheckPassedGameObjects(IList<GameObject> gameObjects)
        {
            for (int i = 0; i < this.gameObjects.Count; i++)
            {
                if (gameObjects[i] is Item && this.gameObjects[i].Position.X < 5)
                {
                    gameObjects.Remove(this.gameObjects[i]);
                }
            }
        }

        public void MoveShipUp()
        {
            int tmpPositionX = this.gameObjects.First(go => go is Starship).Position.X;
            int tmpPositionY = this.gameObjects.First(go => go is Starship).Position.Y;
            if (tmpPositionY > 0)
            {
                this.gameObjects.First(go => go is Starship).Position = new Position(tmpPositionX, tmpPositionY - 1);
                this.gameObjects.First(go => go is Starship).OldPosition = new Position(tmpPositionX, tmpPositionY);
            }

        }

        public void MoveShipDown()
        {

            int tmpPositionX = this.gameObjects.First(go => go is Starship).Position.X;
            int tmpPositionY = this.gameObjects.First(go => go is Starship).Position.Y;
            if (tmpPositionY < height - 4)
            {
                this.gameObjects.First(go => go is Starship).Position = new Position(tmpPositionX, tmpPositionY + 1);
                this.gameObjects.First(go => go is Starship).OldPosition = new Position(tmpPositionX, tmpPositionY);
            }

        }

        public void DestroyObstacles()
        {
            int maxObstacles = this.gameObjects.Where(go => go is Obstacle).Count();
            int maxProjectiles = this.gameObjects.Where(go => go is Projectile).Count();

            for (int i = 0; i < maxObstacles; i++)
            {
                for (int j = 0; j < maxProjectiles; j++)
                {
                    for (int y = gameObjects[i].Position.Y; y < gameObjects[i].ToPrintArray().GetLength(0); y++)
                    {
                        if (this.gameObjects[i].Position.X == this.gameObjects[j].Position.X && this.gameObjects[i].Position.Y == this.gameObjects[j].Position.Y)
                        {
                            this.gameObjects.Remove(this.gameObjects[i]);
                            this.gameObjects.Remove(this.gameObjects[j]);
//                            this.projectilesOnMap.Remove(this.projectilesOnMap[j]);
                        }
                    }
                }
            }
        }

        public void Shoot()
        {
            Starship tmpShip = (Starship) this.gameObjects.First(go => go is Starship);
            Projectile tmpProjectile = tmpShip.CreateProjectile();

            this.gameObjects.Add(tmpProjectile);
        }

        //public void MoveProjectiles(IList<Projectile> projectiles)
        //{
        //    for (int i = 0; i < this.projectilesOnMap.Count; i++)
        //    {
        //        this.renderer.SetCursor(this.projectilesOnMap[i].Position.X, this.projectilesOnMap[i].Position.Y);
        //        this.renderer.Write("White", this.projectilesOnMap[i].ToPrintArray()[0, 0]);
        //        var position = this.projectilesOnMap[i].Position;
        //        position.X += 1;
        //        this.projectilesOnMap[i].Position = position;
        //        if (this.projectilesOnMap[i].Position.X == width)
        //        {
        //            this.projectilesOnMap.Remove(this.projectilesOnMap[i]);
        //        }
        //    }
        //}

        public void CheckShipLives(Starship ship)
        {
            if (ship.Lives == 0)
            {
                this.IsRunning = false;
            }
        }
	}
}

