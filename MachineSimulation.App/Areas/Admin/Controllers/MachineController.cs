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
					machine.ImageUrl =fileName;
				}

				// Veritabanına kaydetme
				await _machineService.AddMachineAsync(machine);
				return RedirectToAction("Index");
			
		}
	}
}
