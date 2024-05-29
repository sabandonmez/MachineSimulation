using MachineSimulation.App.Areas.Admin.Models;
using MachineSimulation.Business.Abstract;
using MachineSimulation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ModbusAddressController : Controller
    {
        private readonly IModbusAddressService _modbusAddressService;

        public ModbusAddressController(IModbusAddressService modbusAddressService)
        {
            _modbusAddressService = modbusAddressService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ModbusAddressViewModel
            {
                Addresses = await _modbusAddressService.GetAllAddressesAsync(),
                NewAddress = new ModbusAddress()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddAddress()
        {
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(ModbusAddressViewModel viewModel)
        {
            if (viewModel.NewAddress == null || viewModel.NewAddress.Address == 0)
            {
                ModelState.AddModelError("NewAddress.Address", "Address must be a non-zero value.");
                viewModel.Addresses = await _modbusAddressService.GetAllAddressesAsync();
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
