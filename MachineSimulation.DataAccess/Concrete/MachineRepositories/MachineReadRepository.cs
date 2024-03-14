using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.MachineRepositories
{
    public class MachineReadRepository : ReadRepository<Machine>, IMachineReadRepository
    {
        public MachineReadRepository(MachineSimulationContext context) : base(context)
        {
        }
    }
}
