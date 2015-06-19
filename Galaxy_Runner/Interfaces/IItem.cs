using System;

namespace Galaxy_Runner
{
	public interface IItem
	{
		int Size { get; set; }

		char Symbol { get; set; }

		string ToString();
	}
}

