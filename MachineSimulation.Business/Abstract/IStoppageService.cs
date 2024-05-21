using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IStoppageService
    {
        Task<IEnumerable<Stoppage>> GetAllStoppageAsync();
        Task<Stoppage> GetByIdStoppageAsync(int id);
        Task AddStoppageAsync(Stoppage stoppage);
        Task UpdateStoppage(Stoppage stoppage);
        Task<bool> DeleteOneStoppage(int id);
        Task<IEnumerable<Stoppage>> GetStoppagesByMachineIdAsync(int machineId);



    }
}
