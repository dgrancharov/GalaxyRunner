using System;
using System.Text;

namespace Galaxy_Runner
{
	public class Scooter : Starship
	{
		public Scooter (Position position)
			: base(position)
		{
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

