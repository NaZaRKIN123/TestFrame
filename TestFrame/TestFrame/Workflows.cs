using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TestFrame;
using TestFrame.Endpoints;

namespace TestFrame
{
	public class EmpHttpWorkflow /*: HttpWorkflow<EmpEndpoint, EmpDTO>*/
	{
		public EmpDTO GetEmpDTO(string empId)
		{
			return Request.Using(SessionManager.Current).From<EmpEndpoint>().Get<EmpDTO>();
		}

		//public EmpDTO GetEmpDTOFromProj(string empName, string projName)
		//{
		//	string projId = new ProjHttpWorkflow().GetProjId(projName);

		//	return;
		//}
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






	//public class ProjHttpWorkflow /*: HttpWorkflow<ProjEndpoint, ProjDTO>*/
	//{
	//	public string GetProjId(string name)
	//	{
	//		return GetAll().Where(x => x.Name == name).First().ID;
	//	}

	//}
}
