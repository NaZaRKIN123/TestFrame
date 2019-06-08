using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrame.Endpoints
{
	public interface IEndpoint
	{
		string Resource { get; }
	}
	public class EmpEndpoint : IEndpoint
	{
		public string Resource => "/emp";
	}
	public class ProjEndpoint : IEndpoint
	{
		public string Resource => "/proj";
	}
}
