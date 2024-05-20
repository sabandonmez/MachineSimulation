using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.Entities.Concrete;
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

        public async Task<IEnumerable<Parameter>> GetAllParameterAsync()
        {
            return await _parameterReadRepository.GetAll(false)
                .Include(p => p.Machine)
                .OrderBy(p => p.Machine.MachineName)  // Burada sıralama ekleniyor
                .ThenBy(p => p.ParameterName) // Ekstra bir sıralama ölçütü eklenebilir
                .ToListAsync();

        }
    }
}
