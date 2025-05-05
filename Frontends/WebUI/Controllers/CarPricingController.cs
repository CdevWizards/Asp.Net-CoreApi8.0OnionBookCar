using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    [Route("[controller]")]
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1="Paketler";
            ViewBag.v2="Araç Fiyat Paketleri";
             
            return View();
        }
    }
}