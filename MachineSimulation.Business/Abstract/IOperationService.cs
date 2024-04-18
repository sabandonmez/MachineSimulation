﻿using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IOperationService
    {
        Task<Operation> GetOperationIdByName(string name);
        Task<int?> GetOperationModbusIdAsync(int machineId,string operationName);
    }
}
