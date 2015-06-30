using System;

namespace Galaxy_Runner.Interfaces
{
	public interface IRenderer
	{
		void Write (string foreGroundColor, string message, params object[] parameters);

        void Write(string foreGroundColor, char s);

        void WriteLine(string foreGroundColor, string message, params object[] parameters);

		void WriteLine ();

        void Clear();
	}
}

