﻿using MachineSimulation.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IAuthService _authService;

        public RoleController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View(_authService.Roles);
        }
    }
}
