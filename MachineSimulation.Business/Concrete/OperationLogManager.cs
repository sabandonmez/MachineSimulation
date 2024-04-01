using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.MachineLogRepositories;
using MachineSimulation.DataAccess.Abstract.OperationLogRepositories;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class OperationLogManager : IOperationLogService
    {
        private readonly IOperationLogReadRepository  _operationogReadRepository;
        private readonly IOperationLogWriteRepository _operationLogWriteRepository;
        public OperationLogManager(IOperationLogReadRepository operationogReadRepository, IOperationLogWriteRepository operationLogWriteRepository)
        {
            _operationogReadRepository = operationogReadRepository;
            _operationLogWriteRepository = operationLogWriteRepository;
        }

        public async Task AddOperationLogAsync(OperationLog log)
        {
            await _operationLogWriteRepository.AddOperationLogAsync(log);
        }

        public IEnumerable<OperationLog> GetLogsForMachine(int machineId)
        {
            return _operationogReadRepository.GetLogsForMachine(machineId);
            
        }

        public IEnumerable<OperationLogDto> GetOperationLogsWithNames(int machineId)
        {
            return _operationogReadRepository.GetOperationLogsWithNames(machineId);
        }


        public async Task LogActionAsync(OperationLog logEntry)
        {
            await _operationLogWriteRepository.AddAsync(logEntry);
            await _operationLogWriteRepository.SaveAsync();
        }

 
    }
}
