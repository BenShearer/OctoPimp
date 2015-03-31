using System.Collections.Generic;

namespace OctoPimp.Interfaces {
    public interface IOctoServiceWrapper {
        /// <summary>
        /// Gets a list of All Library Variable Sets and their variables
        /// </summary>
        IEnumerable<OctoVariableSet_ViewModel> GetAllVariableSets();
        /// <summary>
        /// Creates a Library Variable Set
        /// </summary>
        /// <param name="name">Name of the new variable set</param>
        OctoVariableSet_ViewModel CreateVariableSet(string name);
        
        /// <summary>
        /// Deletes a variable set 
        /// </summary>
        /// <param name="id"></param>
        void DeleteOctoVariableSet(string id);

        /// <summary>
        /// Moves a variable between variable sets
        /// </summary>
        /// <param name="id">The Id of the variable to be moved</param>
        /// <param name="targetVariableSetId">The Id of the variable set the variable is to be moved To</param>
        /// <param name="originVariableSetId">The Id of the variable set the variable is to be moved From</param>
        IEnumerable<OctoVariableSet_ViewModel> MoveVariable(string id, string targetVariableSetId, string originVariableSetId);
    }
}
