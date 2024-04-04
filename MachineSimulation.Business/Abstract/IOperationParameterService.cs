using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IOperationParameterService
    {

        Task<Dictionary<string, int>> StartProductionAsync(int machineId, int operationId);
    }
}
