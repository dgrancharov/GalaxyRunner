using System;

namespace Galaxy_Runner
{
	public interface IInputReader
	{
		string ReadLine();

		ConsoleKeyInfo ReadKey();
	}
}