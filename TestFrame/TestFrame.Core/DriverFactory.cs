using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFrame.Core
{
	public static class DriverFactory
	{
		private static bool isSeleniumGrid = true;
		private static Dictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>();

		public static IWebDriver New()
		{
			IWebDriver driver;
			var options = new SafariOptions();
			if (isSeleniumGrid)
			{
				//options.AddAdditionalCapability("platform", "windows", true);

				driver = new RemoteWebDriver(new Uri("http://192.168.56.1:4444/wd/hub"), options.ToCapabilities());
			}
			else
			{
				//options.AddArgument("headless");
				new DriverManager().SetUpDriver(new ChromeConfig());
				driver = new RemoteWebDriver(options);
			}
			driver.Manage().Window.Maximize();
			return driver;
		}

		public static void New(string testName)
		{
			drivers.Add(testName, New());
		}

		public static IWebDriver Get(string testName)
		{
			return drivers[testName];
		}

		public static void Quit(string testName)
		{
			drivers[testName].Quit();
			drivers.Remove(testName);
		}
	}
}
