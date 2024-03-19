using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IModbusConnectionService
    {
        ModbusClient GetOrCreateModbusClient(int machineId, string ipAddress, int port, byte slaveId);
        void DisconnectModbusClient(int machineId);
    }
}
