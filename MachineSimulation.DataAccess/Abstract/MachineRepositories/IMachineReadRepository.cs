using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.MachineRepositories
{
    public interface IMachineReadRepository : IReadRepository<Machine>
    {
        public MachineDetailsDto GetMachineDetails(int machineId);
        public List<ParameterDto> GetParameters(int machineId);
    }
}
