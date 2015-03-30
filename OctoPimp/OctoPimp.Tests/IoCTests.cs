using System;
using NUnit.Framework;
using OctoPimp.Interfaces;
using Octopus.Client;
using Shouldly;
using StructureMap;

namespace OctoPimp.Integration.Tests {
    [TestFixture]
    public class IoCTests {
        private static Container container;

        [SetUp]
        public void Setup() {
            container = new Container();
            IoC.RegisterComponents(container);
        }

        [Test]
        public void Components_Register_Correctly() {
            var client = container.GetInstance<IOctopusClient>();

            client.ShouldNotBe(null);

            var repo = container.GetInstance<IOctopusRepository>();
            repo.ShouldNotBe(null);
            var vrSets = repo.LibraryVariableSets.FindAll();

            vrSets.Count.ShouldBeGreaterThan(0);
            Console.Write("{0} variable sets", vrSets.Count);
            var service = container.GetInstance<IOctoServiceWrapper>();
            service.ShouldNotBe(null);
        }

    }
}
