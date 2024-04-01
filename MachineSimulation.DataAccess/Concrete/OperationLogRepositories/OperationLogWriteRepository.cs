using MachineSimulation.DataAccess.Abstract.MachineLogRepositories;
using MachineSimulation.DataAccess.Abstract.OperationLogRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.OperationLogRepositories
{
    public class OperationLogWriteRepository : WriteRepository<OperationLog>, IOperationLogWriteRepository
    {
        private readonly MachineSimulationContext _context;
        public OperationLogWriteRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddOperationLogAsync(OperationLog log)
        {
            await _context.OperationLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
