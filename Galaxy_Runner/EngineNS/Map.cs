using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy_Runner
{
    public class Map
    {
        Random Rand = new Random();

        public Map(int height, int width, IRenderer renderer)
        {
            this.Height = height;
            this.Width = width;
            this.Renderer = renderer;
            this.DataMap = MapInit(new char[Height, Width]);
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public IRenderer Renderer { get; private set; }
        public char[,] DataMap { get; private set; }

        public void UpdateMap(IList<GameObject> gameObjects)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if (DataMap[row, col] == ' ')
                    {
                        foreach (GameObject gameObject in gameObjects)
                        {
                            if(gameObject.Position.X == col && gameObject.Position.Y == row)
                            {
                                InsertObjectInMap(gameObject, DataMap);
                            }
                        }
                    }
                }
            }



            PrintMap(DataMap);
        }

        private void PrintMap(char[,] map)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    this.Renderer.Write(map[row, col]);
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

        private void InsertObjectInMap(GameObject gameObject, char[,] map)
        {
//            Console.WriteLine("Debug\tMap: gameObject.ToPrintArray().GetLength(1) - {0}", gameObject.ToPrintArray().GetLength(1));
//            Console.WriteLine("Debug\tMap: gameObject.ToPrintArray().GetLength(0) - {0}", gameObject.ToPrintArray().GetLength(0));

            for (int row = 0; row < gameObject.ToPrintArray().GetLength(0); row++)
            {
                for (int col = 0; col < gameObject.ToPrintArray().GetLength(1) ; col++)
                {
                    map[row + gameObject.Position.Y, col + gameObject.Position.X] = gameObject.ToPrintArray()[row, col];
                }
            }
        }
    }
}