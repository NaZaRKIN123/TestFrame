using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using TestFrame.Endpoints;

namespace TestFrame
{
	public static class SessionManager
	{
		public static RestClient Current { get; private set; } = Session.Instance;
		public static RestClient New => Current = Session.Instance;

		public static class Session
		{
			private static readonly Uri _uri = new Uri("http://nazar.free.beeceptor.com/");

			public static RestClient Instance
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
			}
			private class NewtonsoftDeserializerWrapper : IDeserializer
			{
				public T Deserialize<T>(IRestResponse response)
				{
					return JsonConvert.DeserializeObject<T>(response.Content);
				}
			}
		}
	}
}
