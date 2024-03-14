using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class OperationManager :IOperationService
    {
        private readonly IOperationReadRepository _operationReadRepository;
        private readonly IOperationWriteRepository _operationWriteRepository;
        public OperationManager(IOperationReadRepository operationReadRepository, IOperationWriteRepository operationWriteRepository)
        {
            _operationReadRepository = operationReadRepository;
            _operationWriteRepository = operationWriteRepository;
        }


    }
}
