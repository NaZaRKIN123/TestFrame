using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace TestFrame
{
	public static class RequestFactory
	{
		private static readonly Uri _uri = new Uri("http://jsonplaceholder.typicode.com/");

		public static RestClient Client
		{
			get
			{
				var client = new RestClient(_uri);
				client.AddHandler("application/json", () => new NewtonsoftDeserializerWrapper());
				client.AddHandler("text/json", () => new NewtonsoftDeserializerWrapper());
				client.AddHandler("text/x-json", () => new NewtonsoftDeserializerWrapper());
				client.AddHandler("text/javascript", () => new NewtonsoftDeserializerWrapper());
				client.AddHandler("*+json", () => new NewtonsoftDeserializerWrapper());
				return client;
			}
			set => Client = value;
		}

		public static T Get<T>() where T : IResource, new()
		{
			return Get<T>(new Dictionary<string, string>());
		}

		public static T Get<T>(Dictionary<string, string> segments) where T : IResource, new()
		{
			var resource = new T().Resource;

			if (segments.Count > 0)
			{
				resource += "?";
				var segmentsList = segments.Select(kvp => $"{kvp.Key}={kvp.Value}");
				resource += string.Join("&", segmentsList);
			}
			var request = new RestRequest(resource, Method.GET);
			var res = Client.Execute<T>(request);
			return res.Data;
		}
	}
	//public class By
	//{
	//	public Id(int id)
	//	{
	//		return $"";
	//	}
	//}
	public class Post : PostResource
	{
		public int userId;
		public int id;
		public string title;
		public string body;
	}
	public abstract class PostResource : IResource
	{
		public string Resource => "/posts";
	}
	public interface IResource
	{
		string Resource { get; }
	}
	public class NewtonsoftDeserializerWrapper : IDeserializer
	{
		public T Deserialize<T>(IRestResponse response)
		{
			return JsonConvert.DeserializeObject<T>(response.Content);
		}
	}
}
