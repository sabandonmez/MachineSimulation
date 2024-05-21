using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.StoppageRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class StoppageManager:IStoppageService
    {
        private readonly IStoppageReadRepository _stoppageReadRepository;
        private readonly IStoppageWriteRepository _stoppageWriteRepository;
        public StoppageManager(IStoppageReadRepository stoppageReadRepository, IStoppageWriteRepository stoppageWriteRepository)
        {
            _stoppageReadRepository = stoppageReadRepository;
            _stoppageWriteRepository = stoppageWriteRepository;
        }

        public async Task AddStoppageAsync(Stoppage stoppage)
        {
           await _stoppageWriteRepository.AddAsync(stoppage);
           await _stoppageWriteRepository.SaveAsync();
        }

        public async Task<bool> DeleteOneStoppage(int id)
        {
            var resp = await  _stoppageWriteRepository.RemoveAsync(id);
            if (resp==true)
            {
                await _stoppageWriteRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Stoppage>> GetAllStoppageAsync()
        {
            return await _stoppageReadRepository.GetAll(false).
                Include(p => p.Machine)
               .OrderBy(p => p.Machine.MachineName)  // Burada sıralama ekleniyor
               .ToListAsync();
        }

        public async Task<Stoppage> GetByIdStoppageAsync(int id)
        {
           return await _stoppageReadRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Stoppage>> GetStoppagesByMachineIdAsync(int machineId)
        {
            return await _stoppageReadRepository.GetStoppagesByMachineIdAsync(machineId);
        }


        public async Task UpdateStoppage(Stoppage stoppage)
        {
            _stoppageWriteRepository.Update(stoppage);
            await _stoppageWriteRepository.SaveAsync();
        }
    }
}
