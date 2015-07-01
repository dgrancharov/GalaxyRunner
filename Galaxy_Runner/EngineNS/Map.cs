using System;
using System.Collections.Generic;
using System.Linq;
using Galaxy_Runner.Interfaces;
using Galaxy_Runner.GameObjects;
using Galaxy_Runner.GameObjects.Ships;
using Galaxy_Runner.GameObjects.Items.Obstacles;
using Galaxy_Runner.GameObjects.Items.Bonuses;
using Galaxy_Runner.GameObjects.Items.Penalties;

namespace Galaxy_Runner.EngineNS
{
    public class Map
    {
        Random Rand = new Random();

        public Map(int height, int width, int reducedWidth, IRenderer renderer)
        {
            this.Height = height;
            this.Width = width;
            this.ReducedWidth = reducedWidth;
            this.Renderer = renderer;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public int ReducedWidth { get; set; }
        public IRenderer Renderer { get; private set; }

        public void UpdateMap(Starship playerShip, IList<GameObject> gameObjects)
        {
             foreach (GameObject go in gameObjects)
             {
//                 this.Renderer.Clear();
                 this.Renderer.SetCursor(go.Position.X, go.Position.Y);
                 PrintGameObject(go);
             }
        }
        
        private void PrintGameObject(GameObject gameObject)
        {
            string color;
            for (int row = 0; row < gameObject.ToPrintArray().GetLength(0); row++)
            {
                for (int col = 0; col < gameObject.ToPrintArray().GetLength(1); col++)
                {
                    if(gameObject is Starship)
                    {
                        color = "White";
                        this.Renderer.Write(color, gameObject.ToPrintArray()[row, col]);
                    }
                    else if (gameObject is Obstacle)
                    {
                        color = "DarkYellow";
                        this.Renderer.Write(color, gameObject.ToPrintArray()[row, col]);
                    }
                    else if(gameObject is Bonus)
                    {
                        color = "Green";
                        this.Renderer.Write(color, gameObject.ToPrintArray()[row, col]);
                    }
                    else if (gameObject is Penalty)
                    {
                        color = "Red";
                        this.Renderer.Write(color, gameObject.ToPrintArray()[row, col]);
                    }
                }
                this.Renderer.WriteLine();
                this.Renderer.SetCursor(gameObject.Position.X, gameObject.Position.Y + row + 1);
            }
        }
    }
}