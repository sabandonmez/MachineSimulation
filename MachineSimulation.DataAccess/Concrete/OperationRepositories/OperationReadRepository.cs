using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.OperationRepositories
{
    public class OperationReadRepository : ReadRepository<Operation>, IOperationReadRepository
    {
        public OperationReadRepository(MachineSimulationContext context) : base(context)
        {
        }
    }
}
