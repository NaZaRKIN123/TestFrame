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
				.From<ProjEndpoint>().ById(2)
				.From<EmpEndpoint>().ById(1)
				.Get<EmpDTO>();

			var emps = Using(session)
				.From<EmpEndpoint>()
				.Get<List<EmpDTO>>();

			var proj1emps = Using(session)
				.From<ProjEndpoint>().ById(1)
				.From<EmpEndpoint>()
				.Get<List<EmpDTO>>();

			var proj1inactiveEmpsDict = Using(session)
				.From<ProjEndpoint>().ById(1)
				.From<EmpEndpoint>().ByQuery(new Dictionary<string, object>()
				{
					["active"] = false,
					["name"] = "john"
				})
				.Get<List<EmpDTO>>();

			var proj1inactiveEmpsAnon = Using(session)
				.From<ProjEndpoint>(1)
				.From<EmpEndpoint>().ByQuery(new
				{
					active = false,
					name = "john"
				})
				.Get<List<EmpDTO>>();
		}
	}
}
