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
			return (T)context.Test.Properties.Get(nameof(T));
		}
	}
}
