using Exam3.Business.Profiles;
using Exam3.Business.Repositories.Interfaces;
using Exam3.Business.Services.Interfaces;
using Exam3.Business.ViewModels.CardVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CardController : Controller
    {
        IWebHostEnvironment _env { get; }
        ICardService _service { get; }

        public CardController(ICardService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CardCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _service.Create(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            return View(_service.Update(id));
        }
        [HttpPost]
        public IActionResult Update(int id, CardUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _service.Update(id, vm);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
