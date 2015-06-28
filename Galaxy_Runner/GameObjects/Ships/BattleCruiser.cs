using System;
using System.Text;

namespace Galaxy_Runner
{
	public class BattleCruiser : Starship
	{
		public BattleCruiser (Position position)
			: base(position)
		{
		}

		public override string ToString ()
		{
			StringBuilder shipForm = new StringBuilder ();

			shipForm.AppendLine ("====");
			shipForm.AppendLine (" 888==\\");
			shipForm.AppendLine (" 888==/");
			shipForm.AppendLine ("====");

			return shipForm.ToString ();
		}
	}
}

