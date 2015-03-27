using System.Configuration;
using OctoPimp.Interfaces;
using Octopus.Client;
using StructureMap;

namespace OctoPimp.Tests
{
    public class IoC 
    {
        public static void RegisterComponents(Container container) {
            container.Configure(x => {
                x.For<IOctopusClient>().Use(CreateOctoClient()).Singleton();
                x.For<IOctoServiceWrapper>().Use<OctoServiceWrapper>();
            });
        }

        protected static OctopusClient CreateOctoClient() {

            return new OctopusClient(new OctopusServerEndpoint(ConfigurationManager.AppSettings["Octopus.Endpoint"], ConfigurationManager.AppSettings["Octopus.ApiKey"]));

        }
    }
}
