using System;

namespace Galaxy_Runner
{
	public class ConsoleRenderer : IRenderer
	{
		public void Write(string message, params object[] parameters)
		{
//			Console.SetBufferSize (90, 30);
			Console.Write(message, parameters);
		}

		public void Write(char s)
		{
//			Console.SetBufferSize (90, 30);
			Console.Write(s);
		}

		public void WriteLine(string message, params object[] parameters)
		{
//			Console.SetBufferSize (90, 30);
			Console.WriteLine(message, parameters);
		}

		public void WriteLine()
		{
//			Console.SetBufferSize (90, 30);
			Console.WriteLine();
		}
	}
}

