using System;
using System.Text;

namespace decriptando
{
	internal class Program
	{
		static void Main()
		{
			bool[] bits = GetBitArrayFromHexString();

			bool[] key = GetKey();

			DoppioROR(bits);

			Xor(bits, key);

			string output = BitToString(bits);

			Console.WriteLine(output);

			// Converti la stringa UTF-8 in un array di byte
			byte[] byteArray = Encoding.UTF8.GetBytes(output);

			// Converte ciascun byte in una rappresentazione esadecimale
			string hexString = BitConverter.ToString(byteArray); //.Replace("-", "");

			// Ora, hexString contiene la rappresentazione esadecimale della stringa UTF-8
			Console.WriteLine(hexString);
			Console.WriteLine(hexString.Replace("-", ""));

			Console.WriteLine("\ntheblackpirate:");
			byteArray = Encoding.UTF8.GetBytes("theblackpirate");
			hexString = BitConverter.ToString(byteArray).Replace("-", "");
			Console.WriteLine(hexString);
		}

		static bool[] GetBitArrayFromHexString()
		{
			//25 55 3D F4 31 88 30 14 5C 6C 4C 54 38 11 51 EC 59 45 31 60 4D 78 41 20 18 05 F0 45 5C 0C 59 40 7C 18 18 14 45 25 B4 2D 25 61
			//25553DF4318830145C6C4C54381151EC594531604D7841201805F0455C0C59407C1818144525B42D2561
			string hexString = "25553DF4318830145C6C4C54381151EC594531604D7841201805F0455C0C59407C1818144525B42D2561";
			byte[] byteArray = new byte[hexString.Length / 2];

			// Converti la stringa esadecimale in un array di byte
			for(int i = 0; i < byteArray.Length; i++)
			{
				byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			}

			bool[] bitArray = new bool[byteArray.Length * 8];

			// Converte ciascun byte in un array di 8 bit
			for(int i = 0; i < byteArray.Length; i++)
			{
				byte currentByte = byteArray[i];
				for(int j = 0; j < 8; j++)
				{
					bitArray[i * 8 + j] = ((currentByte >> (7 - j)) & 1) == 1;
				}
			}
			return bitArray;
			// Ora bitArray contiene la rappresentazione binaria della tua stringa esadecimale
			//foreach(bool b in bitArray) Console.Write(b ? "1" : "0");
			//Console.WriteLine();
		}

		static void old_DoppioROR(bool[] bits)
		{
			// Esegui un doppio ROR
			for(int i = 0; i < 2; i++)
			{
				bool carry = bits[bits.Length - 1];
				for(int j = bits.Length - 1; j > 0; j--)
				{
					bits[j] = bits[j - 1];
				}
				bits[0] = carry;
			}
		}

		static void old_DoppioROL(bool[] bits)
		{
			// Esegui un doppio ROL
			for(int i = 0; i < 2; i++)
			{
				bool carry = bits[0];
				for(int j = 0; j < bits.Length - 1; j++)
				{
					bits[j] = bits[j + 1];
				}
				bits[bits.Length-1] = carry;
			}
		}

		static void DoppioROR(bool[] bits)
		{
			//01234567 01234567 //70123456 70123456
			//bitarray / 8 = n byte

			// Esegui un doppio ROR
			for(int rotate = 0; rotate < 2; rotate++)
			{
				for(int bit = 0; bit < bits.Length; bit+=8)
				{
					bool carry = bits[bit+7];
					for(int i = bit+7; i > bit; i--)
						bits[i] = bits[i - 1];
					bits[bit] = carry;
				}
			}
		}

		static bool[] GetKey()
		{
			string keyStr = "theblackpirate";
			keyStr = keyStr + keyStr + keyStr;
			byte[] keyBytes = Encoding.UTF8.GetBytes(keyStr);
			bool[] key = new bool[keyBytes.Length * 8];

			// Converte ciascun byte in un array di 8 bit
			for(int i = 0; i < keyBytes.Length; i++)
			{
				byte currentByte = keyBytes[i];
				for(int j = 0; j < 8; j++)
				{
					key[i * 8 + j] = ((currentByte >> (7 - j)) & 1) == 1;
				}
			}

			return key;
		}

		static void Xor(bool[] bitArray, bool[] key)
		{
			// Esegui l'operazione XOR tra la sequenza di bit e la chiave
			for(int i = 0; i < bitArray.Length; i++)
			{
				bitArray[i] ^= key[i % key.Length];
			}
		}

		static string BitToString(bool[] bitArray)
		{
			byte[] byteArray = new byte[bitArray.Length / 8];

			// Converte i bit in byte
			for(int i = 0; i < byteArray.Length; i++)
			{
				byte value = 0;
				for(int j = 0; j < 8; j++)
				{
					if(bitArray[i * 8 + j])
					{
						value |= (byte)(1 << (7 - j));
					}
				}
				byteArray[i] = value;
			}

			// Converte l'array di byte in una stringa UTF-8
			//return Encoding.ASCII.GetString(byteArray);
			return Encoding.UTF8.GetString(byteArray);
		}
	}
}
