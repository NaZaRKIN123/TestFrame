using System;
using NUnit.Framework;

namespace TestFrame.Core
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
	public class BrowserAttribute : PropertyAttribute
	{
		public BrowserAttribute(Browser type) : base("Browser", type.ToString()) { }
	}
}
