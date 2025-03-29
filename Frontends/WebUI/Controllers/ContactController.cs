using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.ContactDtos;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(ResultContactDto resultContactDto)
        {
            var client= _httpClientFactory.CreateClient();
            resultContactDto.SendDate = DateTime.Now;
            var jsondata = JsonConvert.SerializeObject(resultContactDto);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseMessage=await client.PostAsync("http://localhost:5204/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
