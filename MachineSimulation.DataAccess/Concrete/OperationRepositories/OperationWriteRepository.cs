using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.OperationRepositories
{
    public class OperationWriteRepository : WriteRepository<Operation>, IOperationWriteRepository
    {
        private readonly MachineSimulationContext _machineSimulationContext;
        public OperationWriteRepository(MachineSimulationContext context) : base(context)
        {
            _machineSimulationContext = context;
        }

        public async Task AddMOperationAsync(Operation operation)
        {
           await _machineSimulationContext.Operations.AddAsync(operation);
           await _machineSimulationContext.SaveChangesAsync();
        }
    }
}
