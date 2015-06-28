using System;

namespace Galaxy_Runner
{
	public interface IRenderer
	{
		void Write (string message, params object[] parameters);

		void Write(char s);

		void WriteLine (string message, params object[] parameters);

		void WriteLine ();
	}
}

