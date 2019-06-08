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
			var session = SessionManager.New;

			HttpWorkflow.Get<EmployeeDTO>.From<EmployeesEndpoint>.ById("");
		}
	}
}
