
namespace TestFrame.Core.Endpoints
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
