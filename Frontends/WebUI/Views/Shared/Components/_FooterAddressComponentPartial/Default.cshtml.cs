using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebUI.Views.Shared.Components._FooterAddressComponentPartial
{
    public class Default : PageModel
    {
        private readonly ILogger<Default> _logger;

        public Default(ILogger<Default> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}