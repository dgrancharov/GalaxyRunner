using System;

namespace Galaxy_Runner
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

