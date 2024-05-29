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
        private readonly IModbusAddressService _modbusAddressService;

        // Sabit Modbus bağlantı parametreleri
        private readonly string ipAddress = "192.168.0.231";
        private readonly int port = 502;
        private readonly byte slaveId = 1;

        public ModbusController(IModbusConnectionService modbusConnectionService, IOperationService operationService, IModbusAddressService modbusAddressService)
        {
            _modbusConnectionService = modbusConnectionService;
            _operationService = operationService;
            _modbusAddressService = modbusAddressService;
        }

        public Task<ActionResult> StartPreparation(int machineId, int operationNameId)
        {
            return WriteModbusRegister(machineId, false, operationNameId);
        }

        public Task<ActionResult> StopPreparation(int machineId, int operationNameId)
        {
            return WriteModbusRegister(machineId, true, operationNameId);
        }

        public Task<ActionResult> StartBasedOnSpecificReason(int machineId, int operationNameId)
        {
            return WriteModbusRegister(machineId, false, operationNameId);
        }

        public Task<ActionResult> StopBasedOnSpecificReason(int machineId, int operationNameId)
        {
            return WriteModbusRegister(machineId, true, operationNameId);
        }

        public Task<ActionResult> StartProduction(int machineId, int operationNameId)
        {
            return WriteModbusRegister(machineId, true, operationNameId);
        }


        public Task<ActionResult> StopProduction(int machineId, int operationName)
        {
            return WriteModbusRegister(machineId, false, operationName);
        }

        public Task<ActionResult> StopAutomaticProduction(int machineId,int registerİntValue, int operationNameId)
        {
            return WriteModbusRegister(machineId, registerİntValue, operationNameId);
        }
        


        [HttpPost]
        [Route("/modbus/writestrings")]
        public async Task<ActionResult> WriteStringsToModbus([FromBody] WriteStringsModel model)
        {
            if (model == null)
            {
                return BadRequest("Request body is null.");
            }

            if (model.Strings == null || !model.Strings.Any())
            {
                return BadRequest("Strings are required.");
            }

            var addresses = await _modbusAddressService.GetAllAddressesAsync();
            if (addresses.Count < model.Strings.Count)
            {
                return BadRequest("Not enough addresses configured.");
            }

            var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(model.MachineId, ipAddress, port, slaveId);

            for (int i = 0; i < model.Strings.Count; i++)
            {
                var str = model.Strings[i];
                if (ushort.TryParse(str, out ushort value))
                {
                    // ushort değeri olarak yaz
                    modbusClient.WriteSingleRegister(addresses[i].Address, value);
                }
                else if (str == "0" || str == "1")
                {
                    // Bit değeri olarak yaz (coil olarak)
                    bool bitValue = str == "1";
                    modbusClient.WriteSingleCoil(addresses[i].Address, bitValue);
                }
                else
                {
                    return BadRequest("Each string must be a valid ushort or a bit ('0' or '1').");
                }
            }

            return Json(new { success = true });
        }




        [NonAction]
        private async Task<ActionResult> WriteModbusRegister(int machineId, bool registerValue , int operationNameId)
        {
            try
            {
                var modbusId = await _operationService.GetOperationModbusIdAsync(machineId,operationNameId);
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

        [NonAction]
        private async Task<ActionResult> WriteModbusRegister(int machineId, int registerİntValue, int operationName)
        {
            try
            {
                var modbusId = await _operationService.GetOperationModbusIdAsync(machineId, operationName);
                if (!modbusId.HasValue)
                {
                    return Json(new { success = false, message = "Modbus ID not found." });
                }

                var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, slaveId);
                modbusClient.WriteSingleRegister(modbusId.Value, registerİntValue);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


    }

}