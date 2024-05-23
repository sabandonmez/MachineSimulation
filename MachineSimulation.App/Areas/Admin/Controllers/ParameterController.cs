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
    public class ParameterController : Controller
    {
        private readonly IParameterService _parameterService;
        private readonly IMachineService _machineService; // Machine servisinden makine listesini almak için

        public ParameterController(IParameterService parameterService, IMachineService machineService)
        {
            _parameterService = parameterService;
            _machineService = machineService;
        }


        public async Task<IActionResult> Index(int? machineId)
        {
            var machines = await _machineService.GetAllMachinesAsync();
            ViewBag.Machines = new SelectList(machines, "Id", "MachineName");

            if (machineId.HasValue && machineId > 0)
            {
                var filteredParameters = await _parameterService.GetParametersByMachineIdAsync(machineId.Value);
                return View(filteredParameters);
            }
            else
            {
                var model = await _parameterService.GetAllParameterAsync();
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
        public async Task<IActionResult> Create([FromForm] Parameter parameter)
        {
          
                await _parameterService.AddParameterAsync(parameter);
            var machines = await _machineService.GetAllMachinesAsync();
            ViewBag.Machines = new SelectList(machines, "Id", "MachineName");
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id)
        {
            var model = await _parameterService.GetByIdParameterAsync(id);
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
        public async Task<IActionResult> Update([FromForm] Parameter parameter)
        {
            var existingParameter = await _parameterService.GetByIdParameterAsync(parameter.Id);
            existingParameter.ParameterName = parameter.ParameterName;

            await _parameterService.UpdateParameter(existingParameter);
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            var existingParameter = await _parameterService.GetByIdParameterAsync(id);
            if (existingParameter == null)
            {
                return NotFound();
            }

            var deleteOperation = await _parameterService.DeleteOneParameter(id); 

            return RedirectToAction("Index");
        }



    }
}
