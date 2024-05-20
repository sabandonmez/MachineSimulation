using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.OperationRepositories
{
    public class OperationReadRepository : ReadRepository<Operation>, IOperationReadRepository
    {
        private readonly MachineSimulationContext _context;
        public OperationReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Operation> GetByMachineIdAndOperationId(int machineId, int id)
        {
            return await _context.Operations.FirstOrDefaultAsync(o => o.MachineId == machineId && o.Id == id);
        }

        public async Task<Operation> GetOperationByIdAsync(int id)
        {
            return await _context.Operations
                                 .Include(o => o.Machine)
                                 .Include(o => o.OperationName)
                                 .Include(o => o.OperationParameters)
                                 .FirstOrDefaultAsync(o => o.Id == id);
        }


        //GetOperationIdByName
        public async Task<Operation> GetOperationIdByName(int name)
        {
           return await _context.Operations.FirstOrDefaultAsync(o => o.OperationNameId==name);
            
        }
        public async Task<int?> GetOperationModbusIdAsync(int machineId, int operationName)
        {
            var operation = await _context.Operations
                                          .FirstOrDefaultAsync(o => o.MachineId == machineId &&
                                                                    o.OperationNameId == operationName);

            // operation null ise, null döner.
            return operation?.ModbusIp;
        }



    }
}
