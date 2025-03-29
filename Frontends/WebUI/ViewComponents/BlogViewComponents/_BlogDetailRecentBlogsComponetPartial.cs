using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogsComponetPartial:ViewComponent
    {
        
         private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailRecentBlogsComponetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // İStekte bulunmak için istemci oluşturduk.
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync
            ("http://localhost:5204/api/Blog/GetLast3BlogsWithAuthorsList");
            if (responseMessage.IsSuccessStatusCode) // durum kodları 200-299
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // dotnet add package Newtonsoft.Json
                // using Newtonsoft.Json;
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(jsonData);
                return View(values);
        }
        return View();
        }
    }
}