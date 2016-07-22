using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserGenerator
{
	public class MegaName
	{
		private string _last;
		public string last
		{
			get
			{
				if (!string.IsNullOrEmpty(_last))
				{
					return _last;
				}
				else
				{
					return "";
				}

			}
			set
			{
				foreach (var l in value)
				{
					if (l != ' ')
					{
						_last = string.Concat(_last, l.ToString());
					}
					else
					{
						break;
					}
				}
			}
		}

		public string second { get; set; }
		public string first { get; set; }

		public bool fe
		{
			get
			{
				if (last.Length >= 1)
				{
					if (last[last.Length - 1] == 'а' || last[last.Length - 1] == 'я')
						return true;
				}
				return false;

			}
		}
		public MegaName()
		{
			
		}

		public MegaName(string target)
		{
			last = target;
		}

		public MegaName(string last, string second, string first) : this(last)
		{
			foreach (var c in second)
			{
				if (char.IsLetter(c))
					this.second = string.Concat(this.second, c);
			}

			foreach (var c in first)
			{
				if (char.IsLetter(c))
					this.first = string.Concat(this.first, c);
			}
		}

		public override string ToString()
		{
			return string.Format(@"{0} {1} {2}", last, first, second);
		}
	}
}
