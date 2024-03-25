using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IOperationLogService
    {
        Task LogActionAsync(OperationLog logEntry);
        IEnumerable<OperationLog> GetLogsForMachine(int machineId);
        IEnumerable<OperationLogDto> GetOperationLogsWithNames(int machineId);
    }
}
