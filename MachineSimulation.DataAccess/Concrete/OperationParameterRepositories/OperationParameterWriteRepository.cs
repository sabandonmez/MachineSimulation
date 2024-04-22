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
    public class OperationParameterWriteRepository : WriteRepository<OperationParameter>, IOperationParameterWriteRepository
    {
        private readonly MachineSimulationContext _context;
        public OperationParameterWriteRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public void AddOperationParameter(int operationId, int parameterId, string parameterValue)
        {
            var operationParameter = new OperationParameter
            {
                OperationId = operationId,
                ParameterId = parameterId,
                ParameterValue = parameterValue
            };

            _context.OperationParameters.Add(operationParameter);
        }

        public async Task DeleteOldestOperationParameterByParameterId(int parameterId)
        {
       
            var oldestParameter = await _context.OperationParameters
                                                .Where(op => op.ParameterId == parameterId)
                                                .OrderBy(op => op.Id) 
                                                .FirstOrDefaultAsync(); // En üstteki (en eski) kaydı al

            if (oldestParameter != null)
            {
                _context.OperationParameters.Remove(oldestParameter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
