using System;

namespace Ragionamenti
{
	internal class Ragionamenti
	{
		static void Main()
		{
			long a = 3;
			string[] chars = new string[a];
			//for(int i = 0; i < chars.Length; i++) chars[i] = $"{(char)i}";
			for(int i = 65; i-65 < chars.Length; i++) chars[i-65] = $"{(char)i}";

			//S = a * (1 - a^n) / (1 - a)
			//long a = 256;
			long n = 3;
			long s = a * (1 - (long)Math.Pow(a, n)) / (1 - a);
			string[] args = new string[s];
			for(long i = 0; i < s; i++) args[i] = "";
			long ca = 0; //counter args
			for(long len = 1; len <= n; len++)
			{
				//int[] ch = new int[len]; for(long ic = 0; ic < len; ic++) ch[ic] = 0; // 0:0..255 1:0..255 ic:0..255
				int[] ch = new int[3]; for(long ic = 0; ic < 3; ic++) ch[ic] = 0; // 0:0..255 1:0..255 ic:0..255

				while(_TotArray(ch) != a * 3)
				{
					/*
					 * 'ca' aumenta dopo ogni 'args' finito (length = 'len')
					 *nn ch[ic] aumenta per ogni 'args' finito, e va da 0 ad 'a'
					 * ic aumenta dopo ogni char inserito, e va da 0 a len-1
					 * 'args' si assegna sempre con  char + args
					 * 
					 * per ogni a^n aumenta ch[n]++ //n=0 ogni 1 // n=1 ogni 3 //n=2 ogni 9 ///n max = len-1
					 */

					//inizio len 1 = ch[0] = 0;

					ca = 0;
					int ic = 0;
					ch[ic] = 0;
					args[ca] = chars[ch[ic]]; //A

					ca++;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //B

					ca++;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //C

					// inizio len 2 = ch[1] = 0;

					ca++;
					ic = 0;
					ch[ic] = 0;
					args[ca] = chars[ch[ic]]; //A
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //AA

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //B
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //AB

					ca++;
					ic = 0;
					ch[ic]++; // ch[ic] < a
					args[ca] = chars[ch[ic]]; //C
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //AC

					// len-1 = 1
					ch[1]++;

					ca++;
					ic = 0;
					//ch[ic]++; = 3. 3 = 0
					ch[ic] = 0;
					args[ca] = chars[ch[ic]]; //A
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //BA

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //B
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //BB

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //C
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //BC

					// len-1 = 1
					ch[1]++; //char 3/C

					ca++;
					ic = 0;
					//ch[ic]++; = 3. 3 = 0
					ch[ic] = 0;
					args[ca] = chars[ch[ic]]; //A
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //CA

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //B
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //CB

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //C
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //CC

					// inizio len 3 = ch[2] = 0;
					//ch[ic]++; = 3. 3 = 0
					ch[1] = 0;

					ca++;
					ic = 0;
					//ch[ic]++; = 3. 3 = 0
					ch[ic] = 0;
					args[ca] = chars[ch[ic]]; //A
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //AA
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //AAA

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //B
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //AB
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //AAB

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //C
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //AC
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //AAB


					// len-1 = 1
					ch[1]++;

					ca++;
					ic = 0;
					//ch[ic]++; = 3. 3 = 0
					ch[ic] = 0;
					args[ca] = chars[ch[ic]]; //A
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //BA
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //ABA

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //B
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //BB
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //ABB

					ca++;
					ic = 0;
					ch[ic]++;
					args[ca] = chars[ch[ic]]; //C
					ic++; //ic < len
					args[ca] = chars[ch[ic]] + args[ca]; //BC
					ic++;
					args[ca] = chars[ch[ic]] + args[ca]; //ABC

				}

				/* ****************** */
				for(long ic = 0; ic < len; ic++) //ciclo di ch, indice di ch
				{
					while(ch[ic] < a)
					{
						long c = 0;
						long pow = (long)Math.Pow(a, ic); //				3 ^ 0 =     1;       3 ^ 1 = 3    ^2=9
						for(; c < pow; c++)               //				 ic=0 stamp 1 volta    ic1       ic2=9
						{
							char cha = chars[ch[ic]][0];
							args[ca] = cha + args[ca];
							ca++;
						}
						ch[ic]++;

						//ca -= c-1;

						//end while (posizione x minore di a)
					}


					//end ciclo ic // ciclo ch
				}
				/*
				for(int c = 0; TotArray(ch) != a * len;)
				{
					for(long i = 0; i < len; i++)
						args[ca++] += chars[ch[c]];

					ch[c]++;
					if(ch[c] == a) 
						c++;
				}
				*/

				//end ciclo lunghezza stringa
			}

			//a
			//
			//z
			//aa
			//ab
			//
			//az
			//ba
			//bb
			//
			//bz
			//
			//zz
			//aaa

			foreach(string str in args)
				Console.Write(str + " | ");
		}

		static long _TotArray(int[] array)
		{
			long tot = 0;
			foreach(int i in array) { tot += i; }
			return tot;
		}
	}
}
