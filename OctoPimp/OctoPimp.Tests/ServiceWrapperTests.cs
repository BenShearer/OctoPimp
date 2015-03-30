using System.Linq;
using NUnit.Framework;
using OctoPimp.Interfaces;
using Shouldly;
using StructureMap;

namespace OctoPimp.Integration.Tests {
    [TestFixture]
    public class ServiceWrapperTests {
        private static Container container;

        [SetUp]
        public void Setup() {
            container = new Container();
            IoC.RegisterComponents(container);
        }

        [Test]
        public void Service_Returns_VariableSets() {
            var service = container.GetInstance<IOctoServiceWrapper>();

            var sets = service.GetAllVariableSets();

            sets.ShouldNotBe(null);
            sets.Count().ShouldBeGreaterThan(0);
        }
    }
}
