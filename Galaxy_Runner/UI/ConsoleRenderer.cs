using System;
using Galaxy_Runner.Interfaces;
using Galaxy_Runner.EngineNS;

namespace Galaxy_Runner.UI
{
	public class ConsoleRenderer : IRenderer
	{
		public void Write(string message, params object[] parameters)
		{
            Console.SetWindowSize (121, 30);
            Console.SetBufferSize (121, 30 );
			Console.Write(message, parameters);
		}

		public void Write(char s)
		{
            Console.SetWindowSize (121, 30);
			Console.SetBufferSize (121, 30);
			Console.Write(s);
		}

		public void WriteLine(string message, params object[] parameters)
		{
            Console.SetWindowSize (121, 30);
			Console.SetBufferSize (121, 30);
			Console.WriteLine(message, parameters);
		}

		public void WriteLine()
		{
            Console.SetWindowSize (121, 30);
			Console.SetBufferSize (121, 30);
			Console.WriteLine();
		}

        public void Clear()
        {
            Console.Clear();
        }
	}
}

