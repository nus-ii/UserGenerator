using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace UserGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> feFirstList = ListFromFile(@"FeNames.txt");
			List<string> maFirstList = ListFromFile(@"MaNames.txt");
			List<string> feSecondList = ListFromFile(@"FeSecondNames.txt");
			List<string> maSecodList = ListFromFile(@"MaSecondNames.txt");
			
			List<MegaName> fList=new List<MegaName>();
			List<MegaName> mList=new List<MegaName>();

			var lna = File.ReadLines(@"LastNames.txt");
			foreach (var ln in lna)
			{
				MegaName temp=new MegaName(ln);
				//Console.WriteLine(string.Format("{0} {1}",temp.last,temp.fe));
				if (!string.IsNullOrWhiteSpace(temp.last)&&temp.last.Length>=3)
				{
					if(temp.fe)
					fList.Add(temp);
			
				   if(!temp.fe)
					mList.Add(temp);
				}
			}

			//Console.WriteLine(fList.Count);
			//Console.WriteLine(mList.Count);
			//Console.WriteLine(SuperRandom.RandomString(feFirstList));
			//Console.ReadLine();

			var female = SuperList(fList, feFirstList, feSecondList);
			//PrintMegaList(female);
			//Console.WriteLine(female.Count);
			

			var male = SuperList(mList, maFirstList, maSecodList);
			//PrintMegaList(male);
			//Console.WriteLine(male.Count);
			//Console.ReadLine();

//			Console.ReadLine();

			var megaList=new List<MegaName>();
			megaList.AddRange(male);
			megaList.AddRange(female);

			//User tempUser=new User();

			//tempUser.Role = "Seller";
			//tempUser.fil = "1";
			//tempUser.upr = "1";
			//tempUser.chs = "4";
			//tempUser.med = "0";
			//tempUser.tz = "0";
			//tempUser.act = "CREATE";
			//tempUser.orgA = "ЗАО СК «РСХБ-Страхование»";
			//tempUser.orgB = "Краснодар";
			//tempUser.orgC = "";
			//tempUser.orgD = "";

			var ug=new UserGenerator();
			var tr=new SuperRandom();
			string key = tr.RandomLogin(5);
			Console.WriteLine("Vvedite neobhodimo chislo plzovateley");
			int userNumber = Convert.ToInt32(Console.ReadLine());
			List<User> result = new List<User>();
			User tempc = new User();
			for (int q = 1; q <= userNumber; q++)
			{

				User tempUser = new User();
				tempUser = JsonConvert.DeserializeObject<User>(File.ReadAllText("typicalUser.json"));

				//tempUser.Role = "Seller";
				//tempUser.fil = "1";
				//tempUser.upr = "1";
				//tempUser.chs = "4";
				//tempUser.med = "0";
				//tempUser.tz = "0";
				//tempUser.act = "CREATE";
				//tempUser.orgA = "ЗАО СК «РСХБ-Страхование» ";
				//tempUser.orgB = "Воронеж";
				//tempUser.orgC = "";
				//tempUser.orgD = "";

				tempUser.Name = tr.RandomName(megaList);

				//File.WriteAllText("typicalUser.json",JsonConvert.SerializeObject(tempUser));

				if (tempUser.Name.fe)
				{
					tempUser.Name.second = string.Format("Батьковна {1}-{0}", q,key);
				}
				else
				{
					tempUser.Name.second = string.Format("Батькович {1}-{0}", q,key);
				}
				tempUser.login = tr.RandomLogin(15);
				tempUser.mail = tr.RandomMail();
				tempUser.tabnum = tr.RandomNumber(8);
				result.Add(tempUser);
			}

			foreach (var u in result)
			{
				Console.WriteLine(u.ToString());
			}

			var header = File.ReadLines(@"template.csv");

			string fresult = "";

			foreach (var s in header)
			{
				if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
				{
					if (!string.IsNullOrEmpty(fresult) && !string.IsNullOrWhiteSpace(fresult))
					{
						fresult = string.Concat(fresult, "\r\n", s);
					}
					else
					{
						fresult = s;
					}
				}
			}

			foreach (var u in result)
			{
				fresult = string.Concat(fresult, "\r\n", u.ToString());
			}

			string fileName = FileNameGenerator(@"",".csv",key);
			File.WriteAllText(fileName,fresult,Encoding.UTF8);

			Console.WriteLine(fileName);
			Console.ReadLine();

		}

		private static string FileNameGenerator(string cMytemp, string csv)
		{
			var tr=new SuperRandom();
			var dtn = DateTime.Now;
			string result = string.Format("{0}res_{1}-{2}-{3}_{4}-{5}_{7}{8}", cMytemp, dtn.Day, dtn.Month, dtn.Year, dtn.Hour,
				dtn.Minute, dtn.Second, tr.RandomLogin(5),csv);
			return result;
		}

		private static string FileNameGenerator(string cMytemp, string csv,string key)
		{
			var tr = new SuperRandom();
			var dtn = DateTime.Now;
			string result = string.Format("{0}res_{1}-{2}-{3}_{4}-{5}_{7}{8}", cMytemp, dtn.Day, dtn.Month, dtn.Year, dtn.Hour,
				dtn.Minute, dtn.Second, key, csv);
			return result;
		}



		public static List<string> ListFromFile(string parh)
		{
			List<string> result=new List<string>();
			var tempwet = File.ReadLines(parh);
			foreach (var ws in tempwet)
			{
				result.Add(ws);
			}
			return result;
		}


		public static List<MegaName> SuperList(List<MegaName> target, List<string> firstList, List<string> secondList )
		{
			List<MegaName> result=new List<MegaName>();
			foreach (var t in target)
			{
				foreach (var s in secondList)
				{
					foreach (var f in firstList)
					{
						result.Add(new MegaName(t.last,s,f));
					}
				}
			}

			return result;
		}


		public static void PrintMegaList(List<MegaName> target)
		{
			foreach (var t in target)
			{
				Console.WriteLine(t.ToString());
			}
		}
	
	
	}
		

}
