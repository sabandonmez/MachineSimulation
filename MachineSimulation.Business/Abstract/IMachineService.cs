using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IMachineService
    {
        Task AddMachineAsync(Machine machine);
        Task UpdateMachine(Machine machine);
        Task<IEnumerable<Machine>> GetAllMachinesAsync();
        Task<Machine> GetByIdMachineAsync(int id);
        MachineDetailsDto GetMachineDetails(int machineId);
        List<ParameterDto> GetParameters(int machineId);

    }
}
