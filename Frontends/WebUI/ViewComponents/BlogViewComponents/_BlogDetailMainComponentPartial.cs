using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial:ViewComponent
    {
         private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
             // İStekte bulunmak için istemci oluşturduk.
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync($"http://localhost:5204/api/Blog/"+ id);
            if (responseMessage.IsSuccessStatusCode) // durum kodları 200-299
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // dotnet add package Newtonsoft.Json
                // using Newtonsoft.Json;
                var values = JsonConvert.DeserializeObject<GetBlogById>(jsonData);
                return View(values);
        }
        return View();
        }
}
}