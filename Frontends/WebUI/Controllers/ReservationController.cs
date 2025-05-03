using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.LocationDtos;

namespace WebUI.Controllers
{
    [Route("[controller]")]
    public class ReservationController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1="Araç Kiralama";
            ViewBag.v2="Araç Rezervasyon Formu";

            var client = _httpClientFactory.CreateClient();
    var responseMessage = await client.GetAsync("http://localhost:5204/api/Location");

    if(responseMessage.IsSuccessStatusCode)
    {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.LocationID.ToString()
                                                }).ToList();
                ViewBag.v = values2;
            return View();
        }
        return View();
    }
}
}