using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.OperationLogRepositories
{
    public interface IOperationLogReadRepository : IReadRepository<OperationLog>
    {
        public IEnumerable<OperationLog> GetLogsForMachine(int machineId);
        public IEnumerable<OperationLogDto> GetOperationLogsWithNames(int machineId);
    }
}
