using MachineSimulation.App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MachineSimulation.App.Controllers
{
    //public class AccountController : Controller
    //{
    //    private readonly UserManager<IdentityUser> _userManager;
    //    private readonly SignInManager<IdentityUser> _signInManager;

    //    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }

    //    public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
    //    {
    //        return View(new LoginModel()
    //        {
    //            ReturnUrl = ReturnUrl
    //        });
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Login([FromForm] LoginModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            IdentityUser user = await _userManager.FindByNameAsync(model.Name);
    //            if (user is not null)
    //            {
    //                await _signInManager.SignOutAsync();
    //                if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
    //                {
    //                    return Redirect(model?.ReturnUrl ?? "/");
    //                }
    //            }
    //            ModelState.AddModelError("Error", "Invalid username or password.");
    //        }
    //        return View();
    //    }


    //    public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
    //    {
    //        await _signInManager.SignOutAsync();
    //        return Redirect(ReturnUrl);
    //    }
    //}
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            var model = new LoginModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Name);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(model.ReturnUrl ?? "/");
                    }
                }
                // Kullanıcı adı veya şifre yanlışsa hata mesajı ekleyin
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
    }
}
