using AutoMapper;
using MachineSimulation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Controllers
{
    public class OperationParameterController : Controller
    {
        private readonly IOperationParameterService _operationParameterService;
        private readonly IOperationService _operationService;

        public OperationParameterController(IOperationParameterService operationParameterService, IOperationService operationService)
        {
            _operationParameterService = operationParameterService;
            _operationService = operationService;
        }

        [HttpPost("start/{machineId}")]
        public async Task<IActionResult> StartProduction(int machineId,int operationId)
        {
            try
            {
                var updatedParameters = await _operationParameterService.StartProductionAsync(machineId, operationId);
                // Güncellenen parametreleri 'parameters' anahtarının altında döndürün.
                return Ok(new { message = "Üretim başarıyla başlatıldı.", parameters = updatedParameters });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Üretimi başlatırken bir hata oluştu.", error = ex.Message });
            }
        }


    }
}
