using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Newtonsoft.Json;
using UdemyCarBook.Dto.ServiceDtos;

namespace WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
         public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
        var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync
            ("http://localhost:5204/api/Service");
            if (responseMessage.IsSuccessStatusCode) // durum kodları 200-299
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // dotnet add package Newtonsoft.Json
                // using Newtonsoft.Json;
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
