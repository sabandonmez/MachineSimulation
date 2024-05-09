using MachineSimulation.DataAccess.Abstract.StoppageRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.StoppageRepositories
{
    public class StoppageReadRepository : ReadRepository<Stoppage>, IStoppageReadRepository
    {
        private readonly MachineSimulationContext _context;
        public StoppageReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }
    }
}
