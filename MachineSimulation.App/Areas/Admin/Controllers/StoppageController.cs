﻿using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoppageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
