using System;
using System.Text;

namespace Galaxy_Runner.GameObjects.Ships
{
	public class BattleCruiser : Starship
	{
		public BattleCruiser (Position position)
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
                { '=','=','=','=',' ',' ',' ' },
                { '\\','8','8','8','=','=','\\' },
                { '/','8','8','8','=','=','/' },
                { '=','=','=','=',' ',' ',' ' }
            };

            return tmpCharArray;
        }
	}
}

