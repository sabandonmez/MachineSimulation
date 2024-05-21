using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public interface IParameterService
    {
        Task<IEnumerable<Parameter>> GetAllParameterAsync();
        Task<Parameter> GetByIdParameterAsync(int id);
        Task AddParameterAsync(Parameter parameter);
        Task UpdateParameter(Parameter parameter);
        Task<bool> DeleteOneParameter(int id);
        Task<IEnumerable<Parameter>> GetParametersByMachineIdAsync(int machineId);





    }
}
