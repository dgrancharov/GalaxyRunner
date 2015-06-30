using System;
using System.Collections.Generic;
using System.Linq;
using Galaxy_Runner.Interfaces;
using Galaxy_Runner.GameObjects;
using Galaxy_Runner.GameObjects.Ships;

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
            this.DataMap = MapInit(new char[Height, Width]);
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public int ReducedWidth { get; set; }
        public IRenderer Renderer { get; private set; }
        public char[,] DataMap { get; private set; }

        public void UpdateMap(IList<GameObject> gameObjects, Starship playerShip)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if(col != Width - 1)
                    {
                        DataMap[row, col] = DataMap[row, col + 1];
                    }
                    else
                    {
                        DataMap[row, col] = ' ';
                    }
                }
            }
            RetrieveShip(playerShip);

            this.Renderer.Clear();
            PrintMap(DataMap);
        }

        private void PrintMap(char[,] map)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < ReducedWidth; col++)
                {
                    this.Renderer.Write("Green", map[row, col]);
                }
                this.Renderer.WriteLine();
            }
        }

        private char[,] MapInit(char[,] map)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    map[row, col] = ' ';
                }
            }

            return map;
        }

        private void InsertObjectInMap(GameObject gameObject)
        {
            for (int row = 0; row < gameObject.ToPrintArray().GetLength(0); row++)
            {
                for (int col = 0; col < gameObject.ToPrintArray().GetLength(1) ; col++)
                {
                    DataMap[row + gameObject.Position.Y, col + gameObject.Position.X] = gameObject.ToPrintArray()[row, col];
                }
            }
        }

        private void RetrieveShip(Starship playerShip)
        {
            for (int row = 0; row < playerShip.ToPrintArray().GetLength(0); row++)
            {
                for (int col = 0; col < playerShip.ToPrintArray().GetLength(1); col++)
                {
                    DataMap[row + playerShip.Position.Y, col + playerShip.Position.X] = playerShip.ToPrintArray()[row, col];
                }
            }
        }

        public void PopulateMap(IList<GameObject> gameObjects)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if ( gameObjects.Contains(gameObjects.FirstOrDefault(go => go.Position.X == col && go.Position.Y == row ) ) )
                    {
                        InsertObjectInMap(gameObjects.FirstOrDefault(go => go.Position.X == col && go.Position.Y == row ));
                    }
                }
            }
            PrintMap(DataMap);
            this.Renderer.Clear();
        }
    }
}