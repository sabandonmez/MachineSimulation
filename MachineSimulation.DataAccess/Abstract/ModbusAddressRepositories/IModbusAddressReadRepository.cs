using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.ModbusAddressRepositories
{
    public interface IModbusAddressReadRepository : IReadRepository<ModbusAddress>
    {
        Task<List<ModbusAddress>> GetAddressesByMachineIdAsync(int machineId);
    }
}
