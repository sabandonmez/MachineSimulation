using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class OperationParameterManager :IOperationParameterService
    {
        private readonly IOperationParameterReadRepository _operationParameterReadRepository;
        private readonly IOperationParameterWriteRepository _operationParameterWriteRepository;
        public OperationParameterManager(IOperationParameterReadRepository operationParameterReadRepository, IOperationParameterWriteRepository operationParameterWriteRepository)
        {
            _operationParameterReadRepository = operationParameterReadRepository;
            _operationParameterWriteRepository = operationParameterWriteRepository;
        }
    }
}
