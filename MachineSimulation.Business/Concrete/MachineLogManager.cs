using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.MachineLogRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class MachineLogManager :IMachineLogService
    {

        private readonly IMachineLogReadRepository _machineLogReadRepository;
        private readonly IMachineLogWriteRepository _machineLogWriteRepository;

        public MachineLogManager(IMachineLogReadRepository machineLogReadRepository, IMachineLogWriteRepository machineLogWriteRepository)
        {
            _machineLogReadRepository = machineLogReadRepository;
            _machineLogWriteRepository = machineLogWriteRepository;
        }

        public async Task LogActionAsync(MachineLog logEntry)
        {
            await _machineLogWriteRepository.AddAsync(logEntry);
        }
    }
}
