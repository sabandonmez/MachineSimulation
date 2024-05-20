using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ParameterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
