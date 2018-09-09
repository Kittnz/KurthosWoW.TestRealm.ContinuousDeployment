using System;
using System.Diagnostics;
using System.IO;

namespace KurthosWoW
{
	class Program
	{
		static void Main(string[] args)
		{
			//TODO: We can do some logging or maybe even send some information to a Discord bot.
			//We just directly invoke the batch file that is responsible for handling compilation/git and such.
			//We assume it's in the current directory and that it's named push.bat
			ProcessStartInfo pInfo = new ProcessStartInfo("cmd.exe", $"/c \"{Path.Combine(Directory.GetCurrentDirectory(), "push.bat")}\"");

			pInfo.CreateNoWindow = true;
			pInfo.UseShellExecute = true;

			Process.Start(pInfo).WaitForExit();
		}
	}
}
