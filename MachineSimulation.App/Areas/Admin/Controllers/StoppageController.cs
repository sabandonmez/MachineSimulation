using MachineSimulation.Business.Abstract;
using MachineSimulation.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoppageController : Controller
    {
        private readonly IStoppageService _stoppageService;

        public StoppageController(IStoppageService stoppageService)
        {
            _stoppageService = stoppageService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _stoppageService.GetAllStoppageAsync();
            return View(model);
        }
    }
}
