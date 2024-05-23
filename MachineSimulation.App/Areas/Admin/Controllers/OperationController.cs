using MachineSimulation.Business.Abstract;
using MachineSimulation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.PortableExecutable;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OperationController : Controller
    {
        private readonly IOperationService _operationService;
        private readonly IMachineService _machineService;
        public OperationController(IOperationService operationService, IMachineService machineService)
        {
            _operationService = operationService;
            _machineService = machineService;
        }

        public async Task<IActionResult> Index(int? machineId)
        {
            var machines = await _machineService.GetAllMachinesAsync();
            ViewBag.Machines = new SelectList(machines, "Id", "MachineName");

            if (machineId.HasValue && machineId > 0)
            {
                var filteredOperations = await _operationService.GetOperationsByMachineIdAsync(machineId.Value);
                return View(filteredOperations);
            }
            else
            {
                var model = await _operationService.GetAllOperationsAsync();
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id)
        {
            var model = await _operationService.GetByIdOperationAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] Operation operation)
        {
           
                try
                {
                    await _operationService.UpdateOperation(operation);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                }
            
            return View(operation);
        }



    }
}
