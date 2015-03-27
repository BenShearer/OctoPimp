using System.Collections.Generic;
using System.Linq;
using OctoPimp.Interfaces;
using Octopus.Client;
using Octopus.Client.Model;

namespace OctoPimp {
    public class OctoServiceWrapper : IOctoServiceWrapper{
        private readonly IOctopusClient octopusClient;

        public OctoServiceWrapper(IOctopusClient octopusClient) {
            this.octopusClient = octopusClient;
        }

        public IEnumerable<OctoVariableSet_ViewModel> GetAll() {
            //var vSets = octopusRepository.LibraryVariableSets.FindAll();

            //foreach (var vs in vSets) {

            //    yield return new OctoVariableSet_ViewModel {
            //        Name = vs.Name,
            //        Description = vs.Description,
            //        Id = vs.Id
            //    };
            //}

            var librarySets = octopusClient.List<VariableSetResource>();
            librarySets.Items.ToList().ForEach(x => {
                
                
            });
        }
    }

    public class OctoVariableSet_ViewModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<> 
    }
}
