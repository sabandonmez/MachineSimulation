using MachineSimulation.DataAccess.Abstract.MachineLogRepositories;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.MachineLogRepositories
{
    public class MachineLogReadRepository : ReadRepository<MachineLog>, IMachineLogReadRepository
    {
        private readonly MachineSimulationContext _context;
        public MachineLogReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<MachineLog> GetLogsForMachine(int machineId)
        {
            var logs = _context.MachineLogs
                .Where(log => log.MachineId == machineId)
                .Select(log => new MachineLog
                {
                    MachineId = log.MachineId,
                    Action = log.Action,
                    Timestamp = log.Timestamp
                })
                .ToList();

            return logs;
        }
    }
}
