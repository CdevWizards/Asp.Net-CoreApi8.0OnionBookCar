using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayoutViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial: ViewComponent
    {
     public IViewComponentResult Invoke()
     {
        return View();
     }   
    }
}