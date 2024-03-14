using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.ParameterRepositories
{
    public class ParameterWriteRepository : WriteRepository<Parameter>, IParameterWriteRepository
    {
        public ParameterWriteRepository(MachineSimulationContext context) : base(context)
        {
        }
    }
}
