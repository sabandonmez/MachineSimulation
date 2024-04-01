using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.ParameterRepositories
{
    public interface IParameterReadRepository : IReadRepository<Parameter>
    {
        IEnumerable<Parameter> GetParametersForMachine(int machineId);
    }
}
