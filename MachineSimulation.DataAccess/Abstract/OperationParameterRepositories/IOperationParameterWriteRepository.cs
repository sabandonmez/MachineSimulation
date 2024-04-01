using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.OperationParameterRepositories
{
    public interface IOperationParameterWriteRepository : IWriteRepository<OperationParameter>
    {
        void AddOperationParameter(int operationId, int parameterId, string parameterValue);
    }
}
