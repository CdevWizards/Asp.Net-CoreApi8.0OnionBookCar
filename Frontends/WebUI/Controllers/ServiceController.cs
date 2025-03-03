using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.ServiceDtos;

using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public  ActionResult Index()
        {
             // İStekte bulunmak için istemci oluşturduk.
        ViewBag.v1="Hizmetler";
        ViewBag.v2="Hizmetlerimiz";
        return View();
    }
    }
}
           