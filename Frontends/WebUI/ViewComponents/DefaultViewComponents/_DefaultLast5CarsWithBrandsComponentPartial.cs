using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDtos;

namespace WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial: ViewComponent
    { private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // İStekte bulunmak için istemci oluşturduk.
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync
            ("http://localhost:5204/api/Cars/GetLast5CarWithBrandQueryHandler");
            if (responseMessage.IsSuccessStatusCode) // durum kodları 200-299
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // dotnet add package Newtonsoft.Json
                // using Newtonsoft.Json;
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(jsonData);
                return View(values);
        }
        return View();
    }
    }
}