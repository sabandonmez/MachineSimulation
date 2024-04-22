using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.OperationParameterRepositories
{
    public interface IOperationParameterReadRepository : IReadRepository<OperationParameter>
    {
        Task<int> GetCountByParameterId(int parameterId);
    }
}
