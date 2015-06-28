using System;

namespace Galaxy_Runner
{
	public interface IItem
	{
		int Size { get; set; }

		char ItemSymbol { get; set; }

		string ToString();
	}
}

