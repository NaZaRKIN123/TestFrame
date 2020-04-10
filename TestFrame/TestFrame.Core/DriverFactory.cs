using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFrame.Core
{
	public static class DriverFactory
	{
		private static bool isSeleniumGrid = true;
		private static ConcurrentDictionary<string, IWebDriver> drivers = new ConcurrentDictionary<string, IWebDriver>();

		private static IWebDriver New(Browser browser)
		{
			IWebDriver driver;

			if (isSeleniumGrid)
			{
				DriverOptions options;
				switch (browser)
				{
					case Browser.Safari:
						options = new SafariOptions();
						break;
					case Browser.Chrome:
						options = new ChromeOptions();
						break;
					case Browser.Firefox:
						options = new FirefoxOptions();
						break;
					default:
						throw new NotSupportedException($"'{browser}' is not supported.");
				}
				driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
			}
			else
			{
				switch (browser)
				{
					case Browser.Chrome:
						new DriverManager().SetUpDriver(new ChromeConfig());
						driver = new ChromeDriver();
						break;
					case Browser.Firefox:
						new DriverManager().SetUpDriver(new FirefoxConfig());
						driver = new FirefoxDriver();
						break;
					default:
						throw new NotSupportedException($"'{browser}' is not supported.");
				}
			}
			driver.Manage().Window.Maximize();
			return driver;
		}

		public static void New(string testName, Browser browser)
		{
			if (!drivers.TryAdd(testName, New(browser)))
				throw new ArgumentException($"Driver name: '{testName}' already exists.");
		}

		public static IWebDriver Get(string testName)
		{
			return drivers[testName];
		}

		public static void Quit(string testName)
		{
			if (drivers.TryRemove(testName, out IWebDriver driver))
				driver.Quit();
		}
	}
}
