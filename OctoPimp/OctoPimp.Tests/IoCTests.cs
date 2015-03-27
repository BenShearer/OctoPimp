using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Octopus.Client;
using Shouldly;
using StructureMap;

namespace OctoPimp.Tests
{
    [TestFixture]
    public class IoCTests {
        private static Container container;

        [SetUp]
        public void Setup()
        {
            container = new Container();
            IoC.RegisterComponents(container);
        }

        [Test]
        public void Components_Register_Correctly() {

            var client = container.GetInstance<IOctopusClient>();

            client.ShouldNotBe(null);

            client.

        }
    }
}
