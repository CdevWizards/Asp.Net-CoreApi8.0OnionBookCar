using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.LocationDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminLocationController : Controller
    {
       
       private readonly IHttpClientFactory _httpClientFactory;

        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync("http://localhost:5204/api/Location");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
            return View();
    }
    [HttpGet]
    public ActionResult CreateLocation()
    {
        return View();
    }
    [HttpPost]
    public async Task <IActionResult> CreateLocation(CreateLocationDto createLocationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createLocationDto);
        StringContent stringContent = new StringContent (jsonData, Encoding.UTF8,"application/json");
        var responseMessage = await client.PostAsync("http://localhost:5204/api/Location", stringContent);
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> RemoveLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =await client.DeleteAsync($"http://localhost:5204/api/Location/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5204/api/Location/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
            return View(values);
        }
        return View();
    }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage=await client.PutAsync("http://localhost:5204/api/Location/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
            return RedirectToAction("Index");
            }
              return View();      
        }
    }
}