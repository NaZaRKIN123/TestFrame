using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFrame.Core;

namespace TestFrame.Tests
{
	[TestFixture, Parallelizable]
	class UITests
	{
		[SetUp]
		public void Setup()
		{
			DriverFactory.New(TestContext.CurrentContext.Test.Name,
								TestContext.CurrentContext.Get<Browser>());
		}
		[Test, Browser(Browser.Chrome)]
		public void Test1()
		{
			test();
		}

		[Test, Browser(Browser.Chrome)]
		public void Test2()
		{
			test();
		}

		[Test, Browser(Browser.Chrome)]
		public void Test3()
		{
			test();
		}

		[Test, Browser(Browser.Chrome)]
		public void Test4()
		{
			test();
		}

		[Test, Browser(Browser.Chrome)]
		public void Test5()
		{
			test();
		}
		[Test, Browser(Browser.Chrome)]
		public void Test6()
		{
			test();
		}
		[Test, Browser(Browser.Chrome)]
		public void Test7()
		{
			test();
		}
		[Test, Browser(Browser.Chrome)]
		public void Test8()
		{
			test();
		}
		[Test, Browser(Browser.Chrome)]
		public void Test9()
		{
			test();
		}
		[Test, Browser(Browser.Chrome)]
		public void Test10()
		{
			test();
		}
		[Test, Browser(Browser.Chrome)]
		public void Test11()
		{
			test();
		}
		[TearDown]
		public void Teardown()
		{
			DriverFactory.Quit(TestContext.CurrentContext.Test.Name);
		}

		private void test()
		{
			var driver = DriverFactory.Get(TestContext.CurrentContext.Test.Name);
			driver.Navigate().GoToUrl("https://google.com");
			WaitUntilPageIsReady(driver);
			driver.FindElement(By.XPath("//*[@role='combobox']")).Click();
			driver.FindElement(By.XPath("//*[@role='combobox']")).SendKeys("wikipedia");
			driver.FindElement(By.XPath("//*[@role='combobox']")).SendKeys(Keys.Enter);
			Thread.Sleep(3000);
		}

		private void WaitUntilPageIsReady(IWebDriver driver)
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(10))
				.Until(webDriver => ((IJavaScriptExecutor)webDriver)
									.ExecuteScript("return document.readyState").Equals("complete"));
		}
	}
}
