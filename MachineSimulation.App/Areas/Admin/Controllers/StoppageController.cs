using MachineSimulation.Business.Abstract;
using MachineSimulation.Business.Concrete;
using MachineSimulation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StoppageController : Controller
    {
        private readonly IStoppageService _stoppageService;
        private readonly IMachineService _machineService;

        public StoppageController(IStoppageService stoppageService, IMachineService machineService)
        {
            _stoppageService = stoppageService;
            _machineService = machineService;
        }

        public async Task<IActionResult> Index(int? machineId)
        {
            var machines = await _machineService.GetAllMachinesAsync();
            ViewBag.Machines = new SelectList(machines, "Id", "MachineName");

            if (machineId.HasValue && machineId > 0)
            {
                var filteredStoppages = await _stoppageService.GetStoppagesByMachineIdAsync(machineId.Value);
                return View(filteredStoppages);
            }
            else
            {
                var model = await _stoppageService.GetAllStoppageAsync();
                return View(model);
            }
        }

        public async Task<IActionResult> Create()
        {
            var machines = await _machineService.GetAllMachinesAsync();
            ViewBag.Machines = new SelectList(machines, "Id", "MachineName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Stoppage stoppage)
        {

            await _stoppageService.AddStoppageAsync(stoppage);
            var machines = await _machineService.GetAllMachinesAsync();
            ViewBag.Machines = new SelectList(machines, "Id", "MachineName");
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id)
        {
            var model = await _stoppageService.GetByIdStoppageAsync(id);
            var machine = await _machineService.GetByIdMachineAsync(model.MachineId);

            if (model.Machine == null)
            {
                model.Machine = new Machine();
            }

            model.Machine.MachineName = machine.MachineName; // Makinenin adını modele ekliyoruz
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] Stoppage stoppage)
        {
            var existingStoppage = await _stoppageService.GetByIdStoppageAsync(stoppage.Id);
            existingStoppage.ReasonStoppageName = stoppage.ReasonStoppageName;
            existingStoppage.ReasonStoppageValue = stoppage.ReasonStoppageValue;

            await _stoppageService.UpdateStoppage(existingStoppage);
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            var existingStoppage = await _stoppageService.GetByIdStoppageAsync(id);
            if (existingStoppage == null)
            {
                return NotFound();
            }

            var deleteOperation = await _stoppageService.DeleteOneStoppage(id);

            return RedirectToAction("Index");
        }



    }
}
