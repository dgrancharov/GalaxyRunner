using System;
using Galaxy_Runner.EngineNS.Commands;


namespace Galaxy_Runner.Interfaces
{
	public interface IInputReader
	{
        event ClickEventHandler KeyPress;

        string ReadLine();

        ConsoleKeyInfo ReadKey();

        void IsKeyPressed();
	}
}