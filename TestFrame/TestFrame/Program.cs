using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestFrame.RequestFactory;

namespace TestFrame
{
	class Program
	{
		static void Main(string[] args)
		{
			var a = Get<Post>(new Dictionary<string, string>() { { "id", "2" }, { "userId", "1"} });
		}
	}
}
