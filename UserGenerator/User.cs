using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UserGenerator
{
	public class User
	{
		public MegaName Name { get; set; }

		public string login { get; set; }

		public string Role { get; set; }

		[JsonProperty(PropertyName = "filialCod")]
		public string fil { get; set; }

		[JsonProperty(PropertyName = "UpralvlenieCod")]
		public string upr { get; set; }

		[JsonProperty(PropertyName = "KanalProdazhCod")]
		public string chs { get; set; }

		[JsonProperty(PropertyName = "PosrednikCod")]
		public string med { get; set; }

		public string mail { get; set; }

		[JsonProperty(PropertyName = "VremennayaZona")]
		public string tz { get; set; }

		[JsonProperty(PropertyName = "TabelniyNomer")]
		public string tabnum { get; set; }

		[JsonProperty(PropertyName = "tipDeystviya")]
		public string act { get; set; }

		[JsonProperty(PropertyName = "Companiya")]
		public string orgA { get; set; }
		[JsonProperty(PropertyName = "Podrazdelenie")]
		public string orgB { get; set; }

		[JsonProperty(PropertyName = "DocerniePodrazdelenieA")]
		public string orgC { get; set; }
		[JsonProperty(PropertyName = "DocerniePodrazdelenieB")]
		public string orgD { get; set; }


		public User()
		{
			
		}

		public override string ToString()
		{
			return string.Format("{0};{1};{2};{16};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};"
				,Name.last,Name.first,Name.second,Role,fil,upr,chs,med,mail,tz,tabnum,act,orgA,orgB,orgC,orgD,login);
		}
	}
}
