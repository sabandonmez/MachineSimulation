using MachineSimulation.Business.Abstract;
using MachineSimulation.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ParameterController : Controller
    {
        private readonly IParameterService _parameterService;

        public ParameterController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _parameterService.GetAllParameterAsync();
            return View(model);
        }

        
    }
}
