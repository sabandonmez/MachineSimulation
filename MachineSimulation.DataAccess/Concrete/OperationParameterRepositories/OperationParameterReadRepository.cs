using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.OperationParameterRepositories
{
    public class OperationParameterReadRepository : ReadRepository<OperationParameter>, IOperationParameterReadRepository
    {
        public OperationParameterReadRepository(MachineSimulationContext context) : base(context)
        {
        }
    }
}
