using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.ModbusAddressRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class ModbusAddressManager : IModbusAddressService
    {
        private readonly IModbusAddressReadRepository _readRepository;
        private readonly IModbusAddressWriteRepository _writeRepository;

        public ModbusAddressManager(IModbusAddressReadRepository readRepository, IModbusAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<List<ModbusAddress>> GetAllAddressesAsync()
        {
            return await _readRepository.GetAll().ToListAsync();
        }

        public async Task AddAddressAsync(ModbusAddress address)
        {
            await _writeRepository.AddAsync(address);
            await _writeRepository.SaveAsync();
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _readRepository.GetByIdAsync(id);
            if (address != null)
            {
                _writeRepository.Remove(address);
                await _writeRepository.SaveAsync();
            }
        }
    }

}
