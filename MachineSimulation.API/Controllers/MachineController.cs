using AutoMapper;
using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineSimulation.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MachineController : ControllerBase
	{
		private readonly IMachineService _machineService;

		public IMapper Mapper { get; }
        public MachineController(IMapper mapper, IMachineService machineService)
        {
            Mapper = mapper;
            this._machineService = machineService;
        }

        [HttpPost]
		[Route("api/Machine/Add")]
		public async Task<IActionResult> AddMachine([FromBody] MachineDto machineDto)
		{
			if (ModelState.IsValid)
			{
				var machine = Mapper.Map<Machine>(machineDto);


                await _machineService.AddMachineAsync(machine);

                if (machine.Id > 0) // Eğer bir Id atandıysa
                {
                    machine.ImageUrl = $"{machine.MachineName.Replace(" ", "")}.jpg";
                    await _machineService.UpdateMachine(machine);
                }

                return Ok(machine); 
			}

			return BadRequest(ModelState); 
		}



		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			Machine mach1 = await _machineService.GetByIdMachineAsync(id);
			return Ok(mach1);
		}
	}
}
