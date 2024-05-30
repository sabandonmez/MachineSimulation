using MachineSimulation.DataAccess.Abstract.ModbusAddressRepositories;
using MachineSimulation.DataAccess.Abstract.StoppageRepositories;
using MachineSimulation.DataAccess.Concrete;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.ModbusAddressRepositories
{
    public class ModbusAddressReadRepository : ReadRepository<ModbusAddress>, IModbusAddressReadRepository
    {
        private readonly MachineSimulationContext _context;

        public ModbusAddressReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ModbusAddress>> GetAddressesByMachineIdAsync(int machineId)
        {
            return await _context.ModbusAddresses
                .Where(a => a.MachineId == machineId)
                .ToListAsync();
        }
    }

}
