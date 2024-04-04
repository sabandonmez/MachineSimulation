using EasyModbus;
using MachineSimulation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MachineSimulation.App.Controllers
{
    public class ModbusController : Controller
    {
        private readonly IOperationService _operationService;
        private readonly IModbusConnectionService _modbusConnectionService;

        // Sabit Modbus bağlantı parametreleri
        private readonly string ipAddress = "192.168.0.231";
        private readonly int port = 502;
        private readonly byte slaveId = 1;

        public ModbusController(IModbusConnectionService modbusConnectionService, IOperationService operationService)
        {
            _modbusConnectionService = modbusConnectionService;
            _operationService = operationService;
        }

        public Task<ActionResult> StartPreparation(int machineId)
        {
            return WriteModbusRegister(machineId, 1);
        }

        public Task<ActionResult> StopPreparation(int machineId)
        {
            return WriteModbusRegister(machineId, 0);
        }

        public Task<ActionResult> StartProduction(int machineId)
        {
            return WriteModbusRegister(machineId, 1);
        }


        public Task<ActionResult> StopProduction(int machineId)
        {
            return WriteModbusRegister(machineId, 0);
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


        [NonAction]
        private async Task<ActionResult> WriteModbusRegister(int machineId, ushort registerValue)
        {
            try
            {
                var modbusId = await _operationService.GetOperationModbusIdAsync(machineId);
                if (!modbusId.HasValue)
                {
                    return Json(new { success = false, message = "Modbus ID not found." });
                }

                var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
                modbusClient.WriteSingleRegister(modbusId.Value, registerValue);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }




    }

}