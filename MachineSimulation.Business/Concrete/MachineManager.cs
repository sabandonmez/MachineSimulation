using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
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

        public async Task<bool> DeleteOneMachine(int id)
        {
            return await _machineWriteRepository.DeleteOneMachine(id);
        }


        public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
        {
            return await _machineReadRepository.GetAll(false).ToListAsync();
        }

        public async Task<Machine> GetByIdMachineAsync(int id)
        {
            return await _machineReadRepository.GetByIdAsync(id,false);
        }

        public MachineDetailsDto GetMachineDetails(int machineId)
        {
            return _machineReadRepository.GetMachineDetails(machineId);
        }

        public List<ParameterDto> GetParameters(int machineId)
        {
            return _machineReadRepository.GetParameters(machineId);
        }

        public List<StoppageDto> GetStoppages(int machineId)
        {
            return _machineReadRepository.GetStoppages(machineId);
        }

        public async Task UpdateMachine(Machine machine)
        {
             _machineWriteRepository.Update(machine);
            await _machineWriteRepository.SaveAsync();
        }
    }
}
