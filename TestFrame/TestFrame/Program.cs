using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrame.Endpoints;
using static TestFrame.Request;

namespace TestFrame
{
	class Program
	{
		static void Main(string[] args)
		{
			var session = SessionManager.New;

			var proj2emp1 = Using(session)
				.From<ProjEndpoint>().ById("2")
				.From<EmpEndpoint>().ById("1")
				.Get<EmpDTO>();

			var emps = Using(session)
				.From<EmpEndpoint>()
				.Get<List<EmpDTO>>();

		}
	}
}
