using MachineSimulation.Business.Abstract;
using MachineSimulation.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MachineController : Controller
    {
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly  IMachineService _machineService;

		public MachineController(IMachineService machineService, IWebHostEnvironment hostingEnvironment)
		{
			_machineService = machineService;
			_hostingEnvironment = hostingEnvironment;
		}

		public async Task<IActionResult> Index()
        {
            var model = await  _machineService.GetAllMachinesAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] Machine machine, IFormFile ImageFile)
		{
			
				if (ImageFile != null && ImageFile.Length > 0)
				{
					// MachineName'den dosya adı oluşturma
					var fileName = machine.MachineName.Replace(" ", "") + ".jpg";
					var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "machines", fileName);

					// Dosyayı belirtilen yola kaydetme
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await ImageFile.CopyToAsync(stream);
					}

					// ImageUrl'yi modelde ayarlama
					machine.ImageUrl = fileName;
				}

				// Veritabanına kaydetme
				await _machineService.AddMachineAsync(machine);
				return RedirectToAction("Index");

				
			
		}

		public async Task<IActionResult> Update([FromRoute(Name ="id")] int id)
		{
			var model=await _machineService.GetByIdMachineAsync(id);
			return View(model);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] Machine machine, IFormFile ImageFile)
        {
            var existingMachine = await _machineService.GetByIdMachineAsync(machine.Id);

            if (existingMachine == null)
            {
                return NotFound();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Yeni resim eklenmişse, eski resmi sil ve yenisini kaydet
                if (!string.IsNullOrEmpty(existingMachine.ImageUrl))
                {
                    var oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "machines", existingMachine.ImageUrl);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                var fileName = machine.MachineName.Replace(" ", "") + ".jpg";
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "machines", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                machine.ImageUrl = fileName;
            }
            else
            {
                // Yeni resim eklenmemişse ve makine ismi değişmişse, mevcut resmin ismini güncelle
                if (existingMachine.MachineName != machine.MachineName)
                {
                    var oldFileName = existingMachine.MachineName.Replace(" ", "") + ".jpg";
                    var newFileName = machine.MachineName.Replace(" ", "") + ".jpg";
                    var oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "machines", oldFileName);
                    var newFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "machines", newFileName);

                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Move(oldFilePath, newFilePath);
                        machine.ImageUrl = newFileName;
                    }
                }
                else
                {
                    // Makine ismi değişmemişse mevcut resim URL'sini koru
                    machine.ImageUrl = existingMachine.ImageUrl;
                }
            }

            // Diğer güncellemeleri yap
            existingMachine.MachineName = machine.MachineName;
            existingMachine.ModbusId = machine.ModbusId;
            existingMachine.ImageUrl = machine.ImageUrl;

            await _machineService.UpdateMachine(existingMachine);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete([FromRoute(Name="id")] int id)
        {
            var existingMachine = await  _machineService.GetByIdMachineAsync(id);
           var deleteOperation= _machineService.DeleteOneMachine(id);
            if (deleteOperation.IsCompleted)
            {
				var oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "machines", existingMachine.ImageUrl);
				if (System.IO.File.Exists(oldFilePath))
				{
					System.IO.File.Delete(oldFilePath);
				}
			}
			

			return RedirectToAction("Index");
        }

    }
}
