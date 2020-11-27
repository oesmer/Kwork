using Business.UOW.Abstract;
using Kwork.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class KasaKartController : Controller
    {
        private IUnitOfWork _service;

        public KasaKartController(IUnitOfWork service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var result = _service.KasaKarts.GetAllAsync();
            
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(KasaKart kasa)
        {
            _service.KasaKarts.AddAsync(kasa);
            return View();
        }

    }
}
