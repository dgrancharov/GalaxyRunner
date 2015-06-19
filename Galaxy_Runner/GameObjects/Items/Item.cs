using System;

namespace Galaxy_Runner
{
	public abstract class Item : IItem
	{
		protected Item ()
		{
		}

		public int Size 
		{
			get 
			{
				throw new NotImplementedException ();
			}
			set 
			{
				throw new NotImplementedException ();
			}
		}

		public char Symbol 
		{
			get 
			{
				throw new NotImplementedException ();
			}
			set 
			{
				throw new NotImplementedException ();
			}
		}
	}
}

