using System;
using System.Text;

namespace Galaxy_Runner
{
	public class Catamaran : Starship
	{
		public Catamaran (string name, Position position)
			: base (name, position)
		{
		}

		public override string ToString ()
		{
			StringBuilder shipForm = new StringBuilder ();

			shipForm.AppendLine ("<===>");
			shipForm.AppendLine (" | | ");
			shipForm.AppendLine ("<===>");

			return shipForm.ToString ();
		}
	}
}

