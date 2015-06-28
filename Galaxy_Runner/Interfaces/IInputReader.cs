using System;

namespace Galaxy_Runner.Interfaces
{
	public interface IInputReader
	{
		string ReadLine();

		ConsoleKeyInfo ReadKey();
	}
}