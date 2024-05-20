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

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] Operation operation)
        {
            await _operationService.AddOperationAsync(operation);
            return RedirectToAction("Index");
         
        }

 

    }
}
