using MachineSimulation.DataAccess.Abstract.ModbusAddressRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.ModbusAddressRepositories
{
    public class ModbusAddressWriteRepository : WriteRepository<ModbusAddress>, IModbusAddressWriteRepository
    {
        private readonly MachineSimulationContext _context;

        public ModbusAddressWriteRepository(MachineSimulationContext context):base(context)
        {
            _context = context;
        }
    }
}
