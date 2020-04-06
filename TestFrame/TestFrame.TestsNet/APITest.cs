using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;
using TestFrame.Core;
using TestFrame.Core.Endpoints;
using static TestFrame.Core.Request;

namespace TestFrame.Tests
{
	[TestFixture]
	public class APITests
	{
		private RestClient session;

		[SetUp]
		public void Setup()
		{
			Console.WriteLine("TestFrame.Core API tests Start");
			session = SessionManager.New;
		}

		[Test]
		public void Test1()
		{
			var proj2emp1 = Using(session)
					.From<ProjEndpoint>().ById(2)
					.From<EmpEndpoint>().ById(1)
					.Get<EmpDTO>();

			Assert.Multiple(() =>
			{
				Assert.That(proj2emp1.Name, Is.EqualTo("John"));
				Assert.That(proj2emp1.ID, Is.EqualTo("1"));
			});
		}

		[Test]
		public void Test2()
		{
			var emps = Using(session)
					.From<EmpEndpoint>()
					.Get<List<EmpDTO>>();

			Assert.Multiple(() =>
			{
				Assert.That(emps.Count, Is.EqualTo(3));
				Assert.That(emps, Has.All.InstanceOf<EmpDTO>());
			});
		}

		[Test]
		public void Test3()
		{
			var proj1emps = Using(session)
					.From<ProjEndpoint>().ById(1)
					.From<EmpEndpoint>()
					.Get<List<EmpDTO>>();

			CollectionAssert.IsNotEmpty(proj1emps);
		}

		[Test]
		public void Test4()
		{
			var proj1inactiveEmpsDict = Using(session)
					.From<ProjEndpoint>().ById(1)
					.From<EmpEndpoint>().ByQuery(new Dictionary<string, object>()
					{
						["active"] = false,
						["name"] = "john"
					})
					.Get<List<EmpDTO>>();

			Assert.Multiple(() =>
			{
				Assert.That(proj1inactiveEmpsDict.Count, Is.EqualTo(1));
				Assert.That(proj1inactiveEmpsDict.First().Active, Is.EqualTo(false));
				Assert.That(proj1inactiveEmpsDict.First().ID, Is.EqualTo("1"));
				Assert.That(proj1inactiveEmpsDict.First().Name, Is.EqualTo("John"));
			});
		}

		[Test]
		public void Test5()
		{
			var proj1inactiveEmpsAnon = Using(session)
					.From<ProjEndpoint>(1)
					.From<EmpEndpoint>().ByQuery(new
					{
						active = false,
						name = "john"
					})
					.Get<List<EmpDTO>>();

			Assert.Multiple(() =>
			{
				Assert.That(proj1inactiveEmpsAnon.Count, Is.EqualTo(1));
				Assert.That(proj1inactiveEmpsAnon.First().Active, Is.EqualTo(false));
				Assert.That(proj1inactiveEmpsAnon.First().ID, Is.EqualTo("1"));
				Assert.That(proj1inactiveEmpsAnon.First().Name, Is.EqualTo("John"));
			});
		}

		[TearDown]
		public void Teardown()
		{
			session = null;
			Console.WriteLine("TestFrame.Core API tests End");
		}
	}
}