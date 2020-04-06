using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestFrame.Core
{
	public static class ContextExtensions
	{
		public static T Get<T>(this TestContext context)
		{
			string key = typeof(T).Name;
			string value = string.Empty;
			//if (context.Test.Properties.ContainsKey(key))
				value = context.Test.Properties.Get(key).ToString();
			//else
			//	return Browser.Chrome;
			try
			{
				return (T)Enum.Parse(typeof(T), value);
			}
			catch{ }

			return (T)(object)value;
		}
	}
}
