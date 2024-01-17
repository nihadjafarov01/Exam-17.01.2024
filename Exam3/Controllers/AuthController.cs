using Exam3.Business.Services.Interfaces;
using Exam3.Business.ViewModels.AuthVMs;
using Exam3.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam3.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _service {  get; set; }
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (await _service.Login(vm))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(vm);
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if(await _service.Register(vm))
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(vm);
            }
        }
        public async Task<bool> CreateRoles()
        {
            if(await _service.CreateRoles())
            {
                return true;
            }
            return false;
        }
    }
}
