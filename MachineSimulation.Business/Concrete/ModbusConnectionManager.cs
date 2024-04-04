using EasyModbus;
using MachineSimulation.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class ModbusConnectionManager:IModbusConnectionService
    {
        private readonly Dictionary<int, ModbusClient> _modbusClients = new Dictionary<int, ModbusClient>();

        public ModbusClient GetOrCreateModbusClient(int machineId, string ipAddress, int port, byte slaveId)
        {
            if (!_modbusClients.TryGetValue(machineId, out ModbusClient client))
            {
                client = new ModbusClient(ipAddress, port) { UnitIdentifier = slaveId };
                try
                {
                    client.Connect(); // Bağlantıyı aç
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Modbus bağlantısı açılamadı.");
                }
                _modbusClients[machineId] = client;
            }
            else if (!client.Connected)
            {
                try
                {
                    client.Connect(); // Bağlantıyı tekrar açmaya çalış
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Mevcut Modbus bağlantısı yeniden açılamadı.");
                }
            }

            return client;
        }

        public void DisconnectModbusClient(int machineId)
        {
            if (_modbusClients.TryGetValue(machineId, out ModbusClient client) && client.Connected)
            {
                client.Disconnect();
                _modbusClients.Remove(machineId);
            }
        }
    }

}
