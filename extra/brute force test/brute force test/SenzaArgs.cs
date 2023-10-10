using System;

namespace brute_force_test
{
	internal class SenzaArgs
	{
		static long TotArray(int[] array)
		{
			long tot = 0;
			foreach(int i in array) { tot += i; }
			return tot;
		}

		static void Main()
		{
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

					Console.WriteLine($"Tentativo {ct}: {arg}");

					for(long i = 0; i < len; i++)
						if(ia % (long)Math.Pow(a, i) == 0)
							ch[i]++;
				}
			}
		}
	}

	internal class ConArgs
	{
		static void Main()
		{
			const long a = 256; //(3)tot char da combinare
			string[] chars = new string[a];
			for(int i = 0; i < chars.Length; i++) chars[i] = $"{(char)i}";
			//for(int i = 65; i-65 < chars.Length; i++) chars[i-65] = $"{(char)i}";

			//S = a * (1 - a^n) / (1 - a)
			//long a = 256;
			const long n = 3; //(20)lunghezza massima
			long s = a * (1 - (long)Math.Pow(a, n)) / (1 - a);
			string[] args = new string[s];
			for(long i = 0; i < s; i++) args[i] = "";
			long ca = 0; //counter args
			for(long len = 1; len <= n; len++)
			{
				int[] ch = new int[len]; for(long ic = 0; ic < len; ic++) ch[ic] = 0; // 0:0..255 1:0..255 ic:0..255

				for(long ic = 0, ia = 1; TotArray(ch) != a * len; ic = 0, ia++)
				{
					/*
					 * x 'ca' aumenta dopo ogni 'args' finito (length = 'len')
					 *nn ch[ic] aumenta per ogni 'args' finito, e va da 0 ad 'a-1'
					 * x ic aumenta dopo ogni char inserito, e va da 0 a len-1
					 * x 'args' si assegna sempre con  chars + args
					 * 
					 * per ogni a^n aumenta ch[n]++ //n=0 ogni 1 // n=1 ogni 3 //n=2 ogni 9 ///n max = len-1
					 */

					for(long i = 0; i < len; i++) if(ch[i] == a) ch[i] = 0; //a = 3, se è a 3 allora torna a 0

					for(long i = 0; i < len; i++)
					{
						string cha = chars[ch[ic]];
						args[ca] = chars[ch[ic]] + args[ca];

						ic = (ic == len-1) ? 0 : ic + 1; // len = 3, se è a 2 allora torna a 0
																						 //end chars inseriti // ciclo di inserimento char
					} //1 args finito
					ca++;

					//ch[ic]++;

					for(long i = 0; i < len; i++)
					{
						//divido ia per a^i
						//se true ch[i]++;
						long pow = (long)Math.Pow(a, i);
						if(ia % pow == 0) ch[i]++;
					}

					//end while a * len (ultima combinazione, tutte le combinazioni fatte)
				} // ciclo di inserimento di tutte le combinazioni


				//end ciclo lunghezza stringa
			}

			foreach(string str in args)
				Console.Write(str + " | ");
		}

		static long TotArray(int[] array)
		{
			long tot = 0;
			foreach(int i in array) { tot += i; }
			return tot;
		}
	}
}