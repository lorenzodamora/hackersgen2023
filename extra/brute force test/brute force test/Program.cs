using System;
using System.IO;
using System.Diagnostics;

namespace brute_force_test
{
	internal class Program
	{
		static long TotArray(int[] array)
		{
			long tot = 0;
			foreach(int i in array) { tot += i; }
			return tot;
		}

		static void Main()
		{
			string destfold = @"C:\Users\ldamo\OneDrive\Desktop\test1";

			// Verifica se la cartella di destinazione esiste, altrimenti la crea
			if(!Directory.Exists(destfold)) Directory.CreateDirectory(destfold);

			string path = @"C:\Users\ldamo\OneDrive\Desktop\unzip.bat";

			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = path,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true,
					Verb = "runas", // Avvia il processo come amministratore
				}
			};

			const long a = 256;
			string[] chars = new string[a];
			for(int i = 0; i < chars.Length; i++) chars[i] = $"{(char)i}";

			//S = a * (1 - a^n) / (1 - a)
			const long n = 5;
			long s = a * (1 - (long)Math.Pow(a, n)) / (1 - a);
			Console.WriteLine("Possibili combinazioni totali: " + s);

			long ct = 0; //counter tentativi
			for(long len = 1; len <= n; len++)
			{
				Console.WriteLine("len: " + len);
				int[] ch = new int[len]; for(long ic = 0; ic < len; ic++) ch[ic] = 0;

				for(long ic = 0, ia = 1; TotArray(ch) != a * len; ic = 0, ia++)
				{
					for(long i = 0; i < len; i++) if(ch[i] == a) ch[i] = 0;

					string arg = "";
					for(long i = 0; i < len; i++)
					{
						arg = chars[ch[ic]] + arg;
						ic = (ic == len-1) ? 0 : ic + 1;
					}
					ct++;

					//Console.WriteLine($"Tentativo {ct}: {arg}");
					//if(ct % 10000 == 0) Console.WriteLine(ct + " | ");

					process.StartInfo.Arguments = arg;

					//Console.WriteLine("start");
					process.Start();
					process.WaitForExit();
					//Console.WriteLine("exit");

					if(process.ExitCode == 10)
					{
						Console.WriteLine($"\nBruteforce completato in {ct} tentativi. La password era {arg}");
						File.WriteAllText(@"C:\Users\ldamo\OneDrive\Desktop\password.txt", arg);
						Console.ReadKey(true);
						return;
					}
					process.Close();

					for(long i = 0; i < len; i++)
						if(ia % (long)Math.Pow(a, i) == 0)
							ch[i]++;
				}
			}
		}
	}
}
