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

        public async Task<IEnumerable<Stoppage>> GetAllStoppageAsync()
        {
            return await _stoppageReadRepository.GetAll(false).
                Include(p => p.Machine)
               .OrderBy(p => p.Machine.MachineName)  // Burada sıralama ekleniyor
               .ToListAsync();
        }
    }
}
