using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFrame.Tests
{
	[TestFixture, Parallelizable]
	class UITests
	{
		private IWebDriver driver;
		private bool isSeleniumGrid = false;

		[SetUp]
		public void Setup()
		{
			if (isSeleniumGrid)
			{
				var options = new ChromeOptions();
				options.AddAdditionalCapability("platform", "windows", true);

				driver = new RemoteWebDriver(new Uri("http://192.168.56.1:4444/wd/hub"), options.ToCapabilities());
			}
			else
			{
				new DriverManager().SetUpDriver(new ChromeConfig());
				driver = new ChromeDriver();
			}
			driver.Manage().Window.Maximize();
		}

		[Test, Parallelizable]
		public void Test1()
		{
			Console.WriteLine("Test1 begin");
			test();
			Console.WriteLine("Test1 end");
		}

		[Test, Parallelizable]
		public void Test2()
		{
			Console.WriteLine("Test2 begin");
			test();
			Console.WriteLine("Test2 end");
		}

		[Test, Parallelizable]
		public void Test3()
		{
			Console.WriteLine("Test3 begin");
			test();
			Console.WriteLine("Test3 end");
		}

		[Test, Parallelizable]
		public void Test4()
		{
			Console.WriteLine("Test4 begin");
			test();
			Console.WriteLine("Test4 end");
		}

		[Test, Parallelizable]
		public void Test5()
		{
			Console.WriteLine("Test5 begin");
			test();
			Console.WriteLine("Test5 end");
		}

		[TearDown]
		public void Teardown()
		{
			driver.Quit();
		}

		private void test()
		{
			driver.Navigate().GoToUrl("https://google.com");
			WaitUntilPageIsReady();
			driver.FindElement(By.XPath("//*[@role='combobox']")).Click();
			driver.FindElement(By.XPath("//*[@role='combobox']")).SendKeys("wikipedia");
			driver.FindElement(By.XPath("//*[@role='combobox']")).SendKeys(Keys.Enter);
			Thread.Sleep(3000);
		}

		private void WaitUntilPageIsReady()
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(10))
				.Until(webDriver => ((IJavaScriptExecutor)webDriver)
									.ExecuteScript("return document.readyState").Equals("complete"));
		}
	}
}
