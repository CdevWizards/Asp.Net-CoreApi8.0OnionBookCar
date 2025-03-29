using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.FooterAddressDtos;

namespace WebUI.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class AdminFooterAddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFooterAddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync("http://localhost:5204/api/FooterAddress");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);
            }
            return View();
    }
    [HttpGet]
    public ActionResult CreateFooterAddress()
    {
        return View();
    }
    [HttpPost]
    public async Task <IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddressDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFooterAddressDto);
        StringContent stringContent = new StringContent (jsonData, Encoding.UTF8,"application/json");
        var responseMessage = await client.PostAsync("http://localhost:5204/api/FooterAddress", stringContent);
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> RemoveFooterAddress(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =await client.DeleteAsync($"http://localhost:5204/api/FooterAddress/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateFooterAddress(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5204/api/FooterAddress/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(jsonData);
            return View(values);
        }
        return View();
    }
        [HttpPost]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage=await client.PutAsync("http://localhost:5204/api/FooterAddress/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
            return RedirectToAction("Index");
            }
              return View();      
        }
    }
}