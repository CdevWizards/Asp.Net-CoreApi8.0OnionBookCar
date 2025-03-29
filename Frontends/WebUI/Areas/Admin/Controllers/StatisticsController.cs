using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Areas.Admin.Controllers
{
     [Area("admin")]
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}