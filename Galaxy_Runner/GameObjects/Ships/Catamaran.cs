using System;
using System.Text;

namespace Galaxy_Runner.GameObjects.Ships
{
	public class Catamaran : Starship
	{
		public Catamaran (Position position)
			: base (position)
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
                { '<','=','=','=','>' },
                { ' ','|',' ','|',' ' },
                { '<','=','=','=','>' }
            };

            return tmpCharArray;
        }
	}
}

