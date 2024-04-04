using EasyModbus;
using MachineSimulation.App.Models;
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

        [HttpPost]
        [Route("/modbus/writestrings")]
        public ActionResult WriteStringsToModbus([FromBody] WriteStringsModel model)
        {
            if (model == null)
            {
                return BadRequest("Request body is null.");
            }

            if (model.Strings == null || !model.Strings.Any())
            {
                return BadRequest("Strings are required.");
            }

            var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(model.MachineId, ipAddress, port, slaveId);
            var registerValues = new List<ushort>();

            foreach (var str in model.Strings)
            {
                if (str.Length == 2)
                {
                    // Stringin her karakterinin ASCII değerini alın
                    ushort highByte = Convert.ToByte(str[0]);
                    ushort lowByte = Convert.ToByte(str[1]);

                    // ASCII değerlerini birleştir
                    ushort registerValue = (ushort)((highByte << 8) | lowByte);
                    registerValues.Add(registerValue);
                }
                else
                {
                    // Eğer string iki karakterden farklı bir uzunlukta ise hata ver
                    return BadRequest("Each string must contain exactly two characters.");
                }
            }

            ushort startAddress = 4096;
            ushort[] registerArray = registerValues.ToArray();

            int offset = 0;
            while (offset < registerArray.Length)
            {
                int[] intChunk = registerArray.Skip(offset).Take(123).Select(x => (int)x).ToArray();
                modbusClient.WriteMultipleRegisters(startAddress, intChunk);
                startAddress += (ushort)intChunk.Length;
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