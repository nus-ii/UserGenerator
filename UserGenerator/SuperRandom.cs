using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserGenerator
{
	public class SuperRandom
	{
		private Random _localRandom;

		public SuperRandom()
		{
			_localRandom = new Random();
		}

		public static string RandomString(List<string> target)
		{
			Random mr = new Random();
			int b = DateTime.Now.Second + DateTime.Now.Minute+DateTime.Now.Millisecond;
			int t = 0;
			for (int i = 0; i < b; i++)
			{
				t = mr.Next(0, target.Count);
			}
			return target[t];
		}

		public MegaName RandomName(List<MegaName> target)
		{
		
			int b = DateTime.Now.Second + DateTime.Now.Minute+DateTime.Now.Millisecond;
			int t = 0;
			for (int i = 0; i < b; i++)
			{
				t = _localRandom.Next(0, target.Count);
			}
			return target[t];
		}

		public MegaName RandomNameDual(List<MegaName> a, List<MegaName> b)
		{
			int ab = _localRandom.Next(0, 1);

			if (ab == 0)
			{
				return RandomName(a);
			}
			else
			{
				return RandomName(b);
			}
		}

		public string RandomLogin(int length)
		{
			string result="";
			string alb = "qwertyuiopasdfghjklzxcvbnm";

			for (int q = 0; q < length; q++)
			{
				result = string.Concat(result, alb[this._localRandom.Next(0, alb.Length - 1)].ToString());
			}
			return result;
		}

		public string RandomMail()
		{
			return String.Concat(this.RandomLogin(7), "@virtusystems.ru");
		}

		public string RandomNumber(int length)
		{
			string result = "";
			string alb = "0123456789";

			for (int q = 0; q < length; q++)
			{
				result = string.Concat(result, alb[this._localRandom.Next(0, alb.Length - 1)].ToString());
			}
			return result;
		}
	}
}
