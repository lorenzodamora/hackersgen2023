using System;
using System.Diagnostics;

namespace brute_force_test
{
	internal class process_bat
	{
		static void Main()
		{
			string path = @"C:\Users\ldamo\OneDrive\Desktop\unzip.bat";
			string arg = "test";

			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = path,
					Arguments = arg,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true,
					Verb = "runas", // Avvia il processo come amministratore
				}
			};

			process.Start();
			process.WaitForExit();

			// Puoi gestire l'output del processo se necessario
			string output = process.StandardOutput.ReadToEnd();
			Console.WriteLine(output);

			int exitCode = process.ExitCode;
			Console.WriteLine($"Codice di uscita: {exitCode}");

			process.Close();

			process.StartInfo.Arguments = "test1";

			process.Start();
			process.WaitForExit();

			// Puoi gestire l'output del processo se necessario
			output = process.StandardOutput.ReadToEnd();
			Console.WriteLine(output);

			exitCode = process.ExitCode;
			Console.WriteLine($"Codice di uscita: {exitCode}");

			process.Close();
		}
	}
}