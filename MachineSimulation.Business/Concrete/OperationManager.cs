using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

        public async Task AddOperationAsync(Operation operation)
        {
            await _operationWriteRepository.AddAsync(operation);
            await _operationWriteRepository.SaveAsync();

        }

        public async Task<IEnumerable<Operation>> GetAllOperationsAsync()
        {
            return await _operationReadRepository
                .GetAll(false)
                .Include(o => o.Machine) // İlişkisel verileri dahil ediyoruz
                .Include(o => o.OperationName) // İlişkisel verileri dahil ediyoruz
                .ToListAsync();
        }

        public async Task<Operation> GetByIdOperationAsync(int id)
        {
            return await _operationReadRepository.GetOperationByIdAsync(id);
        }

        public Task<Operation> GetOperationIdByName(int name)
        {
            return _operationReadRepository.GetOperationIdByName(name);
            
        }
        public async Task<int?> GetOperationModbusIdAsync(int machineId, int operationNameId)
        {
            return await _operationReadRepository.GetOperationModbusIdAsync(machineId,operationNameId);

        }

        public async Task<IEnumerable<Operation>> GetOperationsByMachineIdAsync(int machineId)
        {
            return await _operationReadRepository.GetOperationsByMachineIdAsync(machineId);
        }

        public async Task UpdateOperation(Operation operation)
        {
            _operationWriteRepository.Update(operation);
            await _operationWriteRepository.SaveAsync();
        }
    }
}
