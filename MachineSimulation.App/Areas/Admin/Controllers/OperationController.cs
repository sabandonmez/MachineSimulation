using MachineSimulation.Business.Abstract;
using MachineSimulation.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OperationController : Controller
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _operationService.GetAllOperationsAsync();
            return View(model);
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
