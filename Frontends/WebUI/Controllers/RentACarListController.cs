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

        public async Task<IActionResult> Index(int id)
        {
            // var timeoff = TempData["timeoff"];
            // var timepick = TempData["timepick"];
            // var bookpickdate = TempData["bookpickdate"];
            // var bookoffdate = TempData["bookoffdate"];
            //var locationID = TempData.Keep["locationID"];
             var locationID = TempData.Peek("locationID");


            //filterRentACarDto.locationID = int.Parse(locationID.ToString());
            //filterRentACarDto.available = true;
            id = int.Parse(locationID.ToString());
            
            ViewBag.locationID = locationID; 
            // ViewBag.bookpickdate=bookpickdate;
            // ViewBag.bookoffdate=bookoffdate;
            // ViewBag.timeoff=timeoff;
            // ViewBag.locationID=locationID;
            // ViewBag.timepick=timepick;

             var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5204/api/RentACars?locationID={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}