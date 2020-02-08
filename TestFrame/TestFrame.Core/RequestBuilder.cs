using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TestFrame.Core.Endpoints;

namespace TestFrame.Core
{
	public static class Request
	{
		public static RequestBuilder Using(RestClient session)
		{
			return new RequestBuilder(session);
		}
	}
	public class RequestBuilder
	{
		private string _resource = string.Empty;
		private RestClient _session;
		public RequestBuilder From<T>() where T : IEndpoint, new()
		{
			_resource += new T().Resource;
			return this;
		}

		public RequestBuilder From<T>(object id) where T : IEndpoint, new()
		{
			return From<T>().ById(id);
		}

		public T Get<T>() where T : class, new()
		{
			var request = new RestRequest(_resource, Method.GET);
			var res = _session.Execute<T>(request);
			return res.Data;
		}

		public RequestBuilder ById(object id)
		{
			_resource += "/" + id;
			return this;
		}

		public RequestBuilder ByQuery(Dictionary<string, object> query)
		{
			var filters = query.Select(kvp => $"{kvp.Key}={kvp.Value}");
			_resource += "?" + string.Join("&", filters);
			return this;
		}

		public RequestBuilder ByQuery(object anonymousClass)
		{
			Type type = anonymousClass.GetType();
			PropertyInfo[] fields = type.GetProperties();

			var filters = fields.Select(field => $"{field.Name}={field.GetValue(anonymousClass)}");
			_resource += "?" + string.Join("&", filters);
			return this;
		}

		public RequestBuilder(RestClient session)
		{
			_session = session;
		}
	}
}
