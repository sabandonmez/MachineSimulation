﻿using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Abstract.OperationRepositories
{
    public interface IOperationReadRepository : IReadRepository<Operation>
    {
        public Task<Operation> GetByMachineIdAndOperationId(int machineId, int id);
        public Task<Operation> GetOperationIdByName(string name);
      
        public  Task<int?> GetOperationModbusIdAsync(int machineId,string operationName);
    }
}
