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
			StringBuilder shipForm = new StringBuilder ();

			shipForm.AppendLine (" __  ");
			shipForm.AppendLine ("X__O>");

			return shipForm.ToString ();
		}
	}
}

