using AutoMapper;
using EasyModbus;
using MachineSimulation.Business.Abstract;
using MachineSimulation.Business.Concrete;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Controllers
{
    public class MachineController : Controller
	{
		private readonly IMachineService _machineService;
        private readonly IMachineLogService _machineLogService;
        private readonly IOperationLogService _operationLogService;
        public IMapper Mapper { get; }
        private readonly IModbusConnectionService _modbusConnectionService;


        private ModbusClient _modbusClient;

        public MachineController(IMapper mapper, IMachineService machineService, IMachineLogService machineLogService, IModbusConnectionService modbusConnectionService, IOperationLogService operationLogService)
        {
            Mapper = mapper;
            _machineService = machineService;
            _machineLogService = machineLogService;
            _modbusConnectionService = modbusConnectionService;
            _operationLogService = operationLogService;
        }
        public async Task<IActionResult> Index()
        {
			var model = await _machineService.GetAllMachinesAsync();
			return View(model);
		}


        [HttpGet]
        public async Task<IActionResult> ModbusConnect(int machineId)
        {
            var success = false; // Bağlantı başarılı mı?
            try
            {
                
                    string ipAddress = "192.168.0.231";
                    int port = 502;
                    int slaveId = 1;
                var modbusClient = _modbusConnectionService.GetOrCreateModbusClient(machineId, ipAddress, port, (byte)slaveId);
                modbusClient.Connect();
                success = modbusClient.Connected;
            }
            catch (Exception ex)
            {
                success = false;
                await _machineLogService.LogActionAsync(new MachineLog
                {
                    MachineId = machineId,
                    Action = "Bağlantı Hatası - " + ex.Message,
                    Timestamp = DateTime.UtcNow
                });
            }
            if (success)
            {
                await _machineLogService.LogActionAsync(new MachineLog
                {
                    MachineId = machineId,
                    Action = "Bağlandı",
                    Timestamp = DateTime.UtcNow
                });
            }

            return Ok(success);
        }

        [HttpGet]
        public async Task<IActionResult> ModbusDisconnect(int machineId)
        {
            var success = false;

            try
            {
                _modbusConnectionService.DisconnectModbusClient(machineId);
                success = true;
            }
            catch (Exception ex)
            {
                await _machineLogService.LogActionAsync(new MachineLog
                {
                    MachineId = machineId,
                    Action = "Bağlantı Kesme Hatası - " + ex.Message,
                    Timestamp = DateTime.UtcNow
                });
                return Ok(false);
            }

            if (success)
            {
                await _machineLogService.LogActionAsync(new MachineLog
                {
                    MachineId = machineId,
                    Action = "Kopartıldı",
                    Timestamp = DateTime.UtcNow
                });
            }

            return Ok(success);
        }


        [HttpGet]
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model =  _machineService.GetMachineDetails(id);
            model.OperationLogs = _operationLogService.GetOperationLogsWithNames(id);
            return View(model);
        }

        [HttpGet("Machine/Get/Machine/GetMachineParameters/{id}")]
        public IActionResult GetMachineParameters([FromRoute(Name = "id")] int id)
        {
            var model = _machineService.GetParameters(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet("machine/getLogs/{machineId}")]
        public IActionResult GetLogs(int machineId)
        {
            var logs = _operationLogService.GetLogsForMachine(machineId);
            return Json(logs);
        }


        [HttpPost]
        [Route("/machine/logoperation")]
        public async Task<IActionResult> LogOperation([FromBody] OperationLog operationLog)
        {
            if (operationLog == null)
            {
                return BadRequest("Operation log cannot be null.");
            }

            await _operationLogService.AddOperationLogAsync(operationLog);

            return Ok(new { message = "Log recorded successfully." });
        }

    }
}
