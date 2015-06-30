using System;
using Galaxy_Runner.Interfaces;
using Galaxy_Runner.EngineNS;

namespace Galaxy_Runner.UI
{
	public class ConsoleRenderer : IRenderer
	{
		public void Write(string foreGroundColor, string message, params object[] parameters)
		{
            Console.BackgroundColor = ConsoleColor.Black;
            Type type = typeof(ConsoleColor);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, foreGroundColor);
            Console.SetWindowSize(Galaxy_Runner.EngineNS.Engine.reducedWidth + 1, Galaxy_Runner.EngineNS.Engine.height);
            //          Console.SetBufferSize (Galaxy_Runner.EngineNS.Engine.width + 1, Galaxy_Runner.EngineNS.Engine.height);
			Console.Write(message, parameters);
		}

		public void Write(string foreGroundColor, char s)
		{
            Console.BackgroundColor = ConsoleColor.Black;
            Type type = typeof(ConsoleColor);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, foreGroundColor);
            Console.SetWindowSize(Galaxy_Runner.EngineNS.Engine.reducedWidth + 1, Galaxy_Runner.EngineNS.Engine.height);
            //			Console.SetBufferSize (Galaxy_Runner.EngineNS.Engine.width + 1, Galaxy_Runner.EngineNS.Engine.height);
			Console.Write(s);
		}

		public void WriteLine(string foreGroundColor, string message, params object[] parameters)
		{
            Console.BackgroundColor = ConsoleColor.Black;
            Type type = typeof(ConsoleColor);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, foreGroundColor);
            Console.SetWindowSize(Galaxy_Runner.EngineNS.Engine.reducedWidth + 1, Galaxy_Runner.EngineNS.Engine.height);
            //			Console.SetBufferSize (Galaxy_Runner.EngineNS.Engine.width + 1, Galaxy_Runner.EngineNS.Engine.height);
			Console.WriteLine(message, parameters);
		}

		public void WriteLine()
		{
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(Galaxy_Runner.EngineNS.Engine.reducedWidth + 1, Galaxy_Runner.EngineNS.Engine.height);
            //			Console.SetBufferSize (Galaxy_Runner.EngineNS.Engine.width + 1, Galaxy_Runner.EngineNS.Engine.height);
			Console.WriteLine();
		}

        public void Clear()
        {
            Console.Clear();
        }
	}
}

