using System.Collections.Generic;
using OctoPimp.Interfaces;
using Octopus.Client;
using Octopus.Client.Model;

namespace OctoPimp {
    public class OctoServiceWrapper : IOctoServiceWrapper {
        
        private readonly IOctopusRepository octopusRepository;

        public OctoServiceWrapper(IOctopusRepository octopusRepository) {
          
            this.octopusRepository = octopusRepository;
        }

        public IEnumerable<OctoVariableSet_ViewModel> GetAllVariableSets() {
            var libraryVariableSets = octopusRepository.LibraryVariableSets.FindAll();

            var outputList = new List<OctoVariableSet_ViewModel>();
            foreach (var set in libraryVariableSets) {
                outputList.Add(new OctoVariableSet_ViewModel {
                    Id = set.Id,
                    Description = set.Description,
                    Name = set.Name,
                    Variables = GetVariablesForSet(set)
                });
            }
            return outputList;
        }

        public IEnumerable<OctoVariable_ViewModel> GetVariablesForSet(LibraryVariableSetResource set) {
            
            var variableSetRes = octopusRepository.VariableSets.Get(set.VariableSetId);
            var outputList = new List<OctoVariable_ViewModel>();

            foreach (var octoVar in variableSetRes.Variables) {
                outputList.Add(new OctoVariable_ViewModel {
                    Name = octoVar.Name,
                    Value = octoVar.Value,
                    Id=octoVar.Id

                });
            }
            return outputList;
        }
    }

    public class OctoVariableSet_ViewModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<OctoVariable_ViewModel> Variables { get; set; }
    }

    public class OctoVariable_ViewModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
