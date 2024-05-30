using MachineSimulation.App.Areas.Admin.Models;
using MachineSimulation.Business.Abstract;
using MachineSimulation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ModbusAddressController : Controller
    {
        private readonly IModbusAddressService _modbusAddressService;
        private readonly IMachineService _machineService;

        public ModbusAddressController(IModbusAddressService modbusAddressService,IMachineService machineService)
        {
            _modbusAddressService = modbusAddressService;
            _machineService = machineService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ModbusAddressViewModel
            {
                Addresses = await _modbusAddressService.GetAllAddressesAsync(),
                Machines = await _machineService.GetAllMachineListAsync(),
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddAddress()
        {
            var viewModel = new ModbusAddressViewModel
            {
                Machines = await _machineService.GetAllMachineListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(ModbusAddressViewModel viewModel)
        {
            if (viewModel.NewAddress == null || viewModel.NewAddress.Address == 0)
            {
                ModelState.AddModelError("NewAddress.Address", "Address must be a non-zero value.");
                viewModel.Addresses = await _modbusAddressService.GetAllAddressesAsync();
                viewModel.Machines = await _machineService.GetAllMachineListAsync();
                return View("Index", viewModel);
            }

            await _modbusAddressService.AddAddressAsync(viewModel.NewAddress);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _modbusAddressService.DeleteAddressAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }


}
