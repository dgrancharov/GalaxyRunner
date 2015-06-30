using System;
using System.Text;

namespace Galaxy_Runner.GameObjects.Ships
{
	public class Scooter : Starship
	{
		public Scooter (Position position)
			: base(position)
		{
		}

        public override void UpdatePosition()
        {
            int tmpPositionX = this.Position.X;
            int tmpPositionY = this.Position.Y;

            this.Position = new Position(tmpPositionX - 1, tmpPositionY);
        }

		public override string ToString ()
		{
			return this.Lives.ToString ();
		}
        
        public override char[,] ToPrintArray()
        {
            char[,] tmpCharArray = new char[,]
            { 
                { ' ','_','_',' ',' ' },
                { 'X','_','_','O','>' }
            };

            return tmpCharArray;
        }
	}
}

