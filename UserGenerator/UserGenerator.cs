using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserGenerator
{
	public class UserGenerator
	{
		public SuperRandom tro;

		public UserGenerator()
		{
			tro=new SuperRandom();
		}

		public List<User> GetUser(List<MegaName> nameList, int count,User template,SuperRandom tr)
		{
			List<User> result=new List<User>();

		
			for (int q = 0; q < count; q++)
			{
				User temp = template;
				
				temp.Name = tr.RandomName(nameList);
				temp.login = tr.RandomLogin(8);
				temp.mail = tr.RandomMail();
				temp.tabnum = tr.RandomNumber(8);
				result.Add(temp);
			}

			return result;
		}
	}
}
