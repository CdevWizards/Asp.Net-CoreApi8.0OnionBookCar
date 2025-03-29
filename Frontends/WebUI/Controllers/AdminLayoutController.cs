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
    public class AdminLayoutController : Controller
    {
        private readonly ILogger<AdminLayoutController> _logger;

        public AdminLayoutController(ILogger<AdminLayoutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }
           public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptPartial()
        {
            return PartialView();
        }
    }
}