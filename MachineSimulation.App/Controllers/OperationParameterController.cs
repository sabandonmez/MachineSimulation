using AutoMapper;
using MachineSimulation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Controllers
{
    public class OperationParameterController : Controller
    {
        private readonly IOperationParameterService _operationParameterService;

        public OperationParameterController(IOperationParameterService operationParameterService)
        {
            _operationParameterService = operationParameterService;
        }

        [HttpPost("start/{machineId}")]
        public async Task<IActionResult> StartProduction(int machineId)
        {
            try
            {
                var updatedParameters = await _operationParameterService.StartProductionAsync(machineId);
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
