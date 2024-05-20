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
    public class MachineWriteRepository : WriteRepository<Machine>, IMachineWriteRepository
    {
        private readonly MachineSimulationContext _context;
        public MachineWriteRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddMachineAsync(Machine machine)
        {
            await _context.Machines.AddAsync(machine);
            await _context.SaveChangesAsync();
        }

	
	}
}
