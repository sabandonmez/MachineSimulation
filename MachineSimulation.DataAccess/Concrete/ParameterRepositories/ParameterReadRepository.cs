using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.ParameterRepositories
{
    public class ParameterReadRepository : ReadRepository<Parameter>, IParameterReadRepository
    {
        public ParameterReadRepository(MachineSimulationContext context) : base(context)
        {
        }
    }
}
