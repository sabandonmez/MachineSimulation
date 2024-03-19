using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.MachineLogRepositories
{
    public interface IMachineLogReadRepository : IReadRepository<MachineLog>
    {
    }
}
