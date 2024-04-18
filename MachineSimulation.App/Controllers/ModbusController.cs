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

        public Task<ActionResult> StartPreparation(int machineId, string operationName)
        {
            return WriteModbusRegister(machineId, true,operationName);
        }

        public Task<ActionResult> StopPreparation(int machineId, string operationName)
        {
            return WriteModbusRegister(machineId, false, operationName);
        }

        public Task<ActionResult> StartProduction(int machineId, string operationName)
        {
            return WriteModbusRegister(machineId, true, operationName);
        }


        public Task<ActionResult> StopProduction(int machineId, string operationName)
        {
            return WriteModbusRegister(machineId, false, operationName);
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

            // Her string için bir adres listesi
            ushort[] addresses = new ushort[] { 4250, 4251 };  // Adresleri buraya eklemeye devam et.

            for (int i = 0; i < model.Strings.Count; i++)
            {
                var str = model.Strings[i];
                if (ushort.TryParse(str, out ushort value))
                {
                    // ushort değeri olarak yaz
                    modbusClient.WriteSingleRegister(addresses[i], value);
                }
                else if (str == "0" || str == "1")
                {
                    // Bit değeri olarak yaz (coil olarak)
                    bool bitValue = str == "1";
                    modbusClient.WriteSingleCoil(addresses[i], bitValue);
                }
                else
                {
                    return BadRequest("Each string must be a valid ushort or a bit ('0' or '1').");
                }
            }

            return Json(new { success = true });
        }




        [NonAction]
        private async Task<ActionResult> WriteModbusRegister(int machineId, bool registerValue , string operationName)
        {
            try
            {
                var modbusId = await _operationService.GetOperationModbusIdAsync(machineId,operationName);
                if (!modbusId.HasValue)
                {
                    return Json(new { success = false, message = "Modbus ID not found." });
                }

                var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
                modbusClient.WriteSingleCoil(modbusId.Value, registerValue);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }




    }

}