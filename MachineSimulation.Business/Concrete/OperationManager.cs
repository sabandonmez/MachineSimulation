using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public Task<Operation> GetOperationIdByName(string name)
        {
            return _operationReadRepository.GetOperationIdByName(name);
            
        }
        public async Task<int?> GetOperationModbusIdAsync(int machineId, string operationName)
        {
            return await _operationReadRepository.GetOperationModbusIdAsync(machineId,operationName);

        }
    }
}
