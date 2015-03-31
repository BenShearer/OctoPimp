using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using OctoPimp.Interfaces;
using Octopus.Client;
using Shouldly;
using StructureMap;

namespace OctoPimp.Integration.Tests {
    [TestFixture]
    public class ServiceWrapperTests {
        private static Container container;
        private const string TEST_VARIABLE_SET_NAME = "Integration Tests Test Variable Set";
        
        [SetUp]
        public void Setup() {
            container = new Container();
            IoC.RegisterComponents(container);
            AutoMapperConfig.ConfigureMappings();
        }

        [TearDown]
        public void Teardown() {

        }

        [Test]
        public void Service_Returns_VariableSets() {
            var service = container.GetInstance<IOctoServiceWrapper>();

            var sets = service.GetAllVariableSets();

            sets.ShouldNotBe(null);
            sets.Count().ShouldBeGreaterThan(0);
        }

        [Test]
        public void Creating_A_VariableSet_Works() {
            string resultId="";
            try {

                var service = container.GetInstance<IOctoServiceWrapper>();

                var result = service.CreateVariableSet(TEST_VARIABLE_SET_NAME);
                resultId = result.Id;
                result.Name.ShouldBe(TEST_VARIABLE_SET_NAME);
                service
                    .GetAllVariableSets()
                    .Select(x => x.Name)
                    .Contains(TEST_VARIABLE_SET_NAME).ShouldBe(true);
            } finally {
                //var repo = container.GetInstance<IOctopusRepository>();
                //repo.LibraryVariableSets.Delete(repo.LibraryVariableSets.Get(resultId));

            }

        }
    }
}
