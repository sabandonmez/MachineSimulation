using MachineSimulation.DataAccess.Abstract.MachineLogRepositories;
using MachineSimulation.DataAccess.Abstract.OperationLogRepositories;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.OperationLogRepositories
{
    public class OperationLogReadRepository : ReadRepository<OperationLog>, IOperationLogReadRepository
    {
        private readonly MachineSimulationContext _context;
        public OperationLogReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<OperationLog> GetLogsForMachine(int machineId)
        {
            var logs = _context.OperationLogs
                .Where(log => log.MachineId == machineId)
                .Select(log => new OperationLog
                {
                    OperationId = log.OperationId,
                    Timestamp = log.Timestamp
                })
                .ToList();

            return logs;
        }

        public IEnumerable<OperationLogDto> GetOperationLogsWithNames(int machineId)
        {
            var operationLogs = _context.OperationLogs
                .Where(log => log.MachineId == machineId)
                .Join(_context.Operations, 
                    log => log.OperationId,
                    operation => operation.Id,
                    (log, operation) => new OperationLogDto
                    {
                        Id = log.Id,
                        MachineId = log.MachineId,
                        OperationNameId = operation.OperationNameId, 
                        Timestamp = log.Timestamp
                    })
                .ToList();

            return operationLogs;
        }
    }
}
