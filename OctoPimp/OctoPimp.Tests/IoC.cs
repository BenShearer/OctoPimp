using System.Configuration;
using OctoPimp.Interfaces;
using Octopus.Client;
using StructureMap;

namespace OctoPimp.Integration.Tests
{
    public class IoC {

        private static OctopusServerEndpoint octopusServerEndpoint;

        public static void RegisterComponents(Container container) {
            
            octopusServerEndpoint = new OctopusServerEndpoint(ConfigurationManager.AppSettings["Octopus.Endpoint"], ConfigurationManager.AppSettings["Octopus.ApiKey"]);
            
            container.Configure(x => {
                x.For<IOctopusClient>().Use(new OctopusClient(octopusServerEndpoint)).Singleton();
                x.For<IOctopusRepository>().Use(new OctopusRepository(octopusServerEndpoint));
                x.For<IOctoServiceWrapper>().Use<OctoServiceWrapper>();
            });
        }

    }
}
