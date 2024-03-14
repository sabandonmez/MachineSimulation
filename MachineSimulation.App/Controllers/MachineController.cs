using AutoMapper;
using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Controllers
{
	public class MachineController : Controller
	{
		private readonly IMachineService _machineService;
		public IMapper Mapper { get; }
        public MachineController(IMapper mapper, IMachineService machineService)
        {
            Mapper = mapper;
            _machineService = machineService;
        }
        public async Task<IActionResult> Index()
        {
			var model = await _machineService.GetAllMachinesAsync();
			return View(model);
		}

        public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        {
            var model = await _machineService.GetByIdMachineAsync(id);
            return View(model);
        }

    }
}
