using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.RentACarDtos;

namespace WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(FilterRentACarDto filterRentACarDto)
        {
            var timeoff = TempData["timeoff"];
            var timepick = TempData["timepick"];
            var locationID = TempData["locationID"];
            var bookpickdate = TempData["bookpickdate"];
            var bookoffdate = TempData["bookoffdate"];

            filterRentACarDto.locationID = int.Parse(locationID.ToString());
            filterRentACarDto.available = true;
            
            ViewBag.bookpickdate=bookpickdate;
            ViewBag.bookoffdate=bookoffdate;
            ViewBag.timeoff=timeoff;
            ViewBag.locationID=locationID;
            ViewBag.timepick=timepick;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(locationID);
            StringContent stringContent = new StringContent (jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5204/api/RentACars", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}