using MachineSimulation.Business.Abstract;
using MachineSimulation.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            var users = _authService.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_authService.Roles.Select(n => n.Name).ToList())
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            // Yeni oluşturulan kullanıcıya varsayılan olarak "Editor" rolünü ekleyelim
            userDto.Roles.Add("Editor");

            var result = await _authService.CreateUser(userDto);
            return result.Succeeded
                ? RedirectToAction("Index")
                : View(userDto);
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var result = await _authService.GetUserForUpdate(id);
            if (result == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                var updateResult =  _authService.Update(userDto);
                if (!updateResult.IsCompleted)
                {
                    ModelState.AddModelError("", "Kullanıcı güncellenemedi.");
                    return View(userDto);
                }

                return RedirectToAction("Index");
            }
            return View(userDto);
        }


        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDto()
            {
                UserName = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
        {
            var result = await _authService.ResetPassword(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Şifreniz : En az bir özel karakter (örneğin: !, @, #, $, %, vb.) içermelidir.");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOneUser([FromForm] UserDto model)
        {
            var result = await _authService.DeleteOneUser(model.UserName);

            return result.Succeeded
                ? RedirectToAction("Index")
                : View(model);
        }
    }
}
