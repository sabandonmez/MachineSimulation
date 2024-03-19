using MachineSimulation.DataAccess.Abstract.MachineLogRepositories;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.MachineLogRepositories
{
    public class MachineLogReadRepository : ReadRepository<MachineLog>, IMachineLogReadRepository
    {
        public MachineLogReadRepository(MachineSimulationContext context) : base(context)
        {
        }
    }
}
