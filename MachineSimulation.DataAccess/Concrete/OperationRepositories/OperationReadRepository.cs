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

        //GetOperationIdByName
        public async Task<Operation> GetOperationIdByName(string name)
        {
           return await _context.Operations.FirstOrDefaultAsync(o => o.OperationName==name);
            
        }
        //public async Task<int> GetOperationModbusIdAsync(int machineId)
        //{
        //  var address= await  _context.Operations.FirstOrDefaultAsync(o => o.MachineId == machineId);
        //  return address.ModbusIp;

        //}

    }
}
