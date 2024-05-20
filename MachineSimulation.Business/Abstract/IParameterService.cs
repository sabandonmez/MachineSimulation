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
        
    }
}
