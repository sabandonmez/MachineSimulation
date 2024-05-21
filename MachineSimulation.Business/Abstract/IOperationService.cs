using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IOperationService
    {
        Task AddOperationAsync(Operation operation);
        Task<Operation> GetOperationIdByName(int name);
        Task<int?> GetOperationModbusIdAsync(int machineId,int operationNameId);
        Task<IEnumerable<Operation>> GetAllOperationsAsync();
        Task UpdateOperation(Operation operation);
        Task<Operation> GetByIdOperationAsync(int id);
        Task<IEnumerable<Operation>> GetOperationsByMachineIdAsync(int machineId);

    }
}
