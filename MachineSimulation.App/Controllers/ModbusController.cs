using EasyModbus;
using MachineSimulation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MachineSimulation.App.Controllers
{
    public class ModbusController : Controller
    {
        private readonly IModbusConnectionService _modbusConnectionService;

        // Sabit Modbus bağlantı parametreleri
        private readonly string ipAddress = "192.168.0.231";
        private readonly int port = 502;
        private readonly byte slaveId = 1;

        public ModbusController(IModbusConnectionService modbusConnectionService)
        {
            _modbusConnectionService = modbusConnectionService;
        }

        public ActionResult StartPreparation(int machineId)
        {
            var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
            modbusClient.WriteSingleRegister(4249, 1);
            return Json(new { success = true });
        }

        public ActionResult StopPreparation(int machineId)
        {
            var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
            modbusClient.WriteSingleRegister(4249, 0);
            return Json(new { success = true });
        }

        public ActionResult StartProduction(int machineId)
        {
            var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
            modbusClient.WriteSingleRegister(48, 1);
            return Json(new { success = true });
        }

        public ActionResult StopProduction(int machineId)
        {
            var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
            modbusClient.WriteSingleRegister(4255, 0);
            return Json(new { success = true });
        }

        public ActionResult WriteStringsToModbus(int machineId, List<string> strings)
        {
            var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
            var registerValues = new List<ushort>();

            foreach (var str in strings)
            {
                for (int i = 0; i < str.Length; i += 2)
                {
                    ushort highByte = i < str.Length ? Convert.ToByte(str[i]) : (ushort)0;
                    ushort lowByte = i + 1 < str.Length ? Convert.ToByte(str[i + 1]) : (ushort)0;
                    ushort registerValue = (ushort)((highByte << 8) | lowByte);
                    registerValues.Add(registerValue);
                }
            }

            ushort startAddress = 4096; // Modbus'un beklediği başlangıç adresi.
            ushort[] registerArray = registerValues.ToArray();

            // Kodun burası, her bir register'ı 4096 adresinden başlayarak Modbus'a yazmak için ayarlanmıştır.
            int offset = 0;
            while (offset < registerArray.Length)
            {
                // ushort[]'ı int[]'e dönüştürmek için LINQ kullanın
                int[] intChunk = registerArray.Skip(offset).Take(123).Select(x => (int)x).ToArray();

                // Düzeltilmiş argümanla modbusClient.WriteMultipleRegisters'ı çağırın
                modbusClient.WriteMultipleRegisters(startAddress, intChunk);

                // ushort yerine int dizisinin uzunluğu ile başlangıç adresini güncelleyin
                startAddress += (ushort)intChunk.Length;

                // offset'i int dizisinin uzunluğu kadar artırın
                offset += intChunk.Length;
            }


            return Json(new { success = true });
        }


    }

}
