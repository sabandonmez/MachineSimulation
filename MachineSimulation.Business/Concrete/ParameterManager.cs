using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class ParameterManager :IParameterService
    {
        private readonly IParameterReadRepository _parameterReadRepository;
        private readonly IParameterWriteRepository _parameterWriteRepository;
        public ParameterManager(IParameterReadRepository parameterReadRepository, IParameterWriteRepository parameterWriteRepository)
        {
            _parameterReadRepository = parameterReadRepository;
            _parameterWriteRepository = parameterWriteRepository;
        }

        public async Task AddParameterAsync(Parameter parameter)
        {
            await _parameterWriteRepository.AddAsync(parameter);
            await _parameterWriteRepository.SaveAsync();
        }

        public async Task<bool> DeleteOneParameter(int id)
        {
         var resp=  await _parameterWriteRepository.RemoveAsync(id);

            if (resp == true)
            {
                await _parameterWriteRepository.SaveAsync();
                return true;
            }
            return false;             
        }

        public async Task<IEnumerable<Parameter>> GetAllParameterAsync()
        {
            return await _parameterReadRepository.GetAll(false)
                .Include(p => p.Machine)
                .OrderBy(p => p.Machine.MachineName)  // Burada sıralama ekleniyor
                .ThenBy(p => p.ParameterName) // Ekstra bir sıralama ölçütü eklenebilir
                .ToListAsync();

        }

        public async Task<Parameter> GetByIdParameterAsync(int id)
        {
            return await _parameterReadRepository.GetByIdAsync(id, false);
        }

        public async Task<IEnumerable<Parameter>> GetParametersByMachineIdAsync(int machineId)
        {
            return await _parameterReadRepository.GetParametersByMachineIdAsync(machineId);
        }

        public async Task UpdateParameter(Parameter parameter)
        {
            _parameterWriteRepository.Update(parameter);
            await _parameterWriteRepository.SaveAsync();
        }

    }
}
