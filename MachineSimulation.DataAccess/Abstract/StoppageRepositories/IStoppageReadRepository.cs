using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.StoppageRepositories
{
    public interface IStoppageReadRepository:IReadRepository<Stoppage>
    {
        Task<IEnumerable<Stoppage>> GetStoppagesByMachineIdAsync(int machineId);
    }
}
