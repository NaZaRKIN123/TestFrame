using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrame.Core.Endpoints;

namespace TestFrame.Core
{
	public class EmpWorkflows /*: HttpWorkflow<EmpEndpoint, EmpDTO>*/
	{
		public EmpDTO GetEmp(string empName)
		{
			return Request.Using(SessionManager.Current)
				.From<EmpEndpoint>()
				.Get<List<EmpDTO>>().First(x => x.Name == empName);
		}

		public List<EmpDTO> GetEmpsFromProj(string empName, string projName)
		{
			string projId = new ProjWorkflows().GetProj(projName).ID;

			return Request.Using(SessionManager.Current)
				.From<ProjEndpoint>().ById(projId)
				.From<EmpEndpoint>()
				.Get<List<EmpDTO>>();
		}
	}
	
	public class ProjWorkflows /*: HttpWorkflow<ProjEndpoint, ProjDTO>*/
	{
		public ProjDTO GetProj(string projName)
		{
			return Request.Using(SessionManager.Current)
				.From<ProjEndpoint>()
				.Get<List<ProjDTO>>().First(x => x.Name == projName);
		}
	}


	//public abstract class HttpWorkflow<Endpoint, DTO> where Endpoint : IEndpoint, new() where DTO : class, new()///: IHttpWorkflow
	//{
	//	protected RestClient _session;
	//	public HttpWorkflow<Endpoint, DTO> In(RestClient session)
	//	{
	//		_session = session;
	//		return this;
	//	}
	//	protected List<DTO> GetAll()
	//	{
	//		var resource = new Endpoint().Resource;

	//		var request = new RestRequest(resource, Method.GET);
	//		var res = _session.Execute<List<DTO>>(request);

	//		return res.Data;
	//	}
	//	protected DTO Get(string id)
	//	{
	//		var resource = new Endpoint().Resource;

	//		var request = new RestRequest(resource + $"/{id}", Method.GET);
	//		var res = _session.Execute<DTO>(request);

	//		return res.Data;
	//	}
	//}






}
