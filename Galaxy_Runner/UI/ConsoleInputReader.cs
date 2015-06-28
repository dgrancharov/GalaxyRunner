using System;
using Galaxy_Runner.Interfaces;

namespace Galaxy_Runner.UI
{
	public class ConsoleInputReader : IInputReader
	{
		public ConsoleInputReader ()
		{
		}

		public string ReadLine()
		{
			string tmpString = Console.ReadLine ();
			return tmpString;
		}

		public ConsoleKeyInfo ReadKey()
		{
			ConsoleKeyInfo cki = Console.ReadKey ();
			return cki;
		}
	}
}

