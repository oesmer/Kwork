using Business.Abstract;
using Business.UOW.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class MasrafKartController : Controller
    {
        //private readonly IUnitOfWork _services;

        //public MasrafKartController(IUnitOfWork services)
        //{
        //    _services = services;
        //}
        private readonly IMasrafKartService _service;

        public MasrafKartController(IMasrafKartService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAll();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return View();
        }
    }
}
