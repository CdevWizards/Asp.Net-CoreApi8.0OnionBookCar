using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;

namespace WebUI.Areas.Admin.Controllers
{
     [Area("admin")]
    public class AdminAboutController : Controller
    {
       
       private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync("http://localhost:5204/api/About");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
    }
    [HttpGet]
    public ActionResult CreateAbout()
    {
        return View();
    }
    [HttpPost]
    public async Task <IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createAboutDto);
        StringContent stringContent = new StringContent (jsonData, Encoding.UTF8,"application/json");
        var responseMessage = await client.PostAsync("http://localhost:5204/api/About", stringContent);
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> RemoveAbout(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =await client.DeleteAsync($"http://localhost:5204/api/About/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateAbout(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5204/api/About/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
            return View(values);
        }
        return View();
    }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage=await client.PutAsync("http://localhost:5204/api/About/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
            return RedirectToAction("Index");
            }
              return View();      
        }
    }
}