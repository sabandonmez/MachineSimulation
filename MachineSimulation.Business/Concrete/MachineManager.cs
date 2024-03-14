using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Services.Concrete
{
    public class MachineManager : IMachineService
    {
        private readonly IMachineReadRepository _machineReadRepository;
        private readonly IMachineWriteRepository _machineWriteRepository;

        public MachineManager(IMachineReadRepository machineReadRepository, IMachineWriteRepository machineWriteRepository)
        {
            _machineReadRepository = machineReadRepository;
            _machineWriteRepository = machineWriteRepository;
        }

        public async Task AddMachineAsync(Machine machine)
        {
            await _machineWriteRepository.AddAsync(machine);
            await _machineWriteRepository.SaveAsync();
        }

        public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
        {
            // GetAll() IQueryable döndürdüğü için, sonuçları bir liste olarak almak için ToListAsync() kullanılır.
            return await _machineReadRepository.GetAll(false).ToListAsync();
        }

        public async Task<Machine> GetByIdMachineAsync(int id)
        {
            return await _machineReadRepository.GetByIdAsync(id,false);
        }

    }
}
