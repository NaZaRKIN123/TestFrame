using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFrame.Tests
{
	[TestFixture]
	class UITests
	{
		private RemoteWebDriver driver;

		[OneTimeSetUp]
		public void Setup()
		{
			new DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
		}
		[Test]
		public void Test1()
		{
			Console.WriteLine("Test1 begin");
			driver.Navigate().GoToUrl("https://facebook.com");
			var el = driver.FindElement(By.XPath("//input[@type='submit']"));
			el.Click();
			Assert.Pass();
			Console.WriteLine("Test1 end");
		}
		[Test]
		public void Test2()
		{
			Console.WriteLine("Test2 begin");
			Assert.Pass();
			Console.WriteLine("Test2 end");
		}
		[Test]
		public void Test3()
		{
			Console.WriteLine("Test3 begin");
			Assert.Fail();
			Console.WriteLine("Test3 end");
		}
		[OneTimeTearDown]
		public void Teardown()
		{
			driver.Quit();
		}
	}
}
