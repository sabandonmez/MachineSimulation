using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.OperationParameterRepositories
{
    public class OperationParameterReadRepository : ReadRepository<OperationParameter>, IOperationParameterReadRepository
    {
        private readonly MachineSimulationContext _context;
        public OperationParameterReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetCountByParameterId(int parameterId)
        {
            return await _context.OperationParameters
                                 .Where(op => op.ParameterId == parameterId)
                                 .CountAsync();
        }

    }
}
