using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
	public class GeneratePass
	{
		private string symbols = "!#$@%^&*+-?";
		private string numbers = "23456789";
		private string lowercase = "abcdefghjkmnpqrstuvwxyz";
		private string uppercase = "ABCDEFGHIJKMNPQRSTUVWXYZ";
		private string similar = "il|1L0Oo";
		private string ambiguous = "{}()[]/~:";

		public string generate(int length, bool smb, bool nmb, bool lc, bool uc, bool sc, bool ac)
		{
			StringBuilder sb = new StringBuilder();
			if (smb == true)
			{
				sb.Append(symbols);
			}
			if (nmb == true)
			{
				sb.Append(numbers);
			}
			if (lc == true)
			{
				sb.Append(lowercase);
			}
			if (uc == true)
			{
				sb.Append(uppercase);
			}
			if (sc == false)
			{
				sb.Append(similar);
			}
			if (ac == false)
			{
				sb.Append(ambiguous);
			}
			Random rnd = new Random();
			StringBuilder password = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				int randomIndex = rnd.Next(sb.Length);
				password.Append(sb[randomIndex]);
			}
			return password.ToString();
		}
	}
}
