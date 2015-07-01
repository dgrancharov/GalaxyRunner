using System;
using System.IO;
using Galaxy_Runner.EngineNS.Commands;
using Galaxy_Runner.Interfaces;

namespace Galaxy_Runner.UI
{
	public class ConsoleInputReader : IInputReader
	{
		public ConsoleInputReader ()
		{
		}

        public event ClickEventHandler KeyPress;

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

        public void IsKeyPressed()
        {
            if (Console.KeyAvailable)
            {
                var keyPressed = this.ReadKey();
                if (keyPressed.Key == ConsoleKey.UpArrow || keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.P || keyPressed.Key == ConsoleKey.Spacebar)
                {
                    if (this.KeyPress != null)
                    {
                        this.KeyPress(this, new ProcessEventArgs(keyPressed.Key));
                    }
                }
            }
        }
	}
}

