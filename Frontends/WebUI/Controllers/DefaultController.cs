using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using UdemyCarBook.Dto.LocationDtos;
using Newtonsoft.Json;


namespace WebUI.Controllers
{
    public class DefaultController : Controller
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
public async Task<IActionResult> Index()
{
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
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string book_pick_date, string book_off_date,string time_pick,string time_off,string locationID)
        {
            TempData["timeoff"] = time_off;
            TempData["timepick"] = time_pick;
            TempData["locationID"] = locationID;
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            return RedirectToAction("Index", "RentACarList");
        }

    }
}