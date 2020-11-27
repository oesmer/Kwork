using Business.UOW.Abstract;
using Kwork.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc.Controllers
{
    public class MasrafDekontController : Controller
    {
        private IUnitOfWork _service;

        public MasrafDekontController(IUnitOfWork service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var result = _service.MasrafDekonts.GetAllAsync();
            return View(result);
        }
        public IActionResult Create()
        {
            ViewBag.MasrafKartID = _service.MasrafDekonts.GetAllAsync();
            ViewBag.KasaKartID = _service.KasaKarts.GetAllAsync();
            ViewBag.BirimKartID = _service.BirimKarts.GetAllAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MasrafDekont masrafIslem)
        {
            _service.MasrafDekonts.AddAsync(masrafIslem);
            _service.SaveAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var masrafDekont = _service.MasrafDekonts.GetAsync(x=>x.Id==id);
            if (masrafDekont == null)
            {
                return NotFound();
            }
            ViewData["BirimKartID"] = new SelectList((System.Collections.IEnumerable)_service.BirimKarts.GetAllAsync(), "Id", "BirimAdi", masrafDekont.Result.BirimKartID);
            ViewData["KasaKartID"] = new SelectList((System.Collections.IEnumerable)_service.KasaKarts.GetAllAsync(), "Id", "KasaAdi", masrafDekont.Result.KasaKartID);
            ViewData["MasrafKartID"] = new SelectList((System.Collections.IEnumerable)_service.MasrafKarts.GetAllAsync(), "Id", "MasrafAdi", masrafDekont.Result.MasrafKartID);
            return View(masrafDekont);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MasrafDekont masrafDekont)
        {
            _service.MasrafDekonts.UpdateAsync(masrafDekont);
            _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
