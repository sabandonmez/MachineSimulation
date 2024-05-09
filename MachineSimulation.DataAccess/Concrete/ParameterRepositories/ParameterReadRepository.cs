using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.ParameterRepositories
{
    public class ParameterReadRepository : ReadRepository<Parameter>, IParameterReadRepository
    {
        private readonly MachineSimulationContext _context;
        public ParameterReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Parameter> GetParametersForMachine(int machineId)
        {
            return _context.Parameters
                .Where(p => p.MachineId == machineId)
                .ToList();
        }

        int IParameterReadRepository.GetCountParameterByMachineIdAsync(int machineId)
        {
            return  _context.Parameters.Where(p => p.MachineId == machineId).Count();
        }
    }
}
