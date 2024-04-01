using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.Entities.Concrete;
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
    }
}
