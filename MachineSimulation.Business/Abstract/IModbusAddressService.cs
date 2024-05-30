using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IModbusAddressService
    {
        Task<List<ModbusAddress>> GetAllAddressesAsync();
        Task AddAddressAsync(ModbusAddress address);
        Task DeleteAddressAsync(int id);
        Task<List<ModbusAddress>> GetAddressesByMachineIdAsync(int machineId);
    }
}
