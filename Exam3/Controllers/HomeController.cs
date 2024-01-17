using Exam3.Business.Services.Interfaces;
using Exam3.Business.ViewModels.CardVMs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Exam3.Controllers
{
    public class HomeController : Controller
    {
        ICardService _service {  get; }

        public HomeController(ICardService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<CardListItemVM> data = _service.GetAll();
            var re =  data.TakeLast(3);
            return View(re);
        }

    }
}