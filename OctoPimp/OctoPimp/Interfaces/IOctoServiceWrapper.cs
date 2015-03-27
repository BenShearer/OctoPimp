using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPimp.Interfaces
{
    public interface IOctoServiceWrapper {
        IEnumerable<OctoVariableSet_ViewModel> GetAll();

    }
}
