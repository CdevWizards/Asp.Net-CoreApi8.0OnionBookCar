using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;   

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ActionResult> Index()
        {
          ViewBag.v1="Yazarlarımızın Blogları";
          ViewBag.v2="Aracınızı Seçiniz";
             // İStekte bulunmak için istemci oluşturduk.
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync
            ("http://localhost:5204/api/Blog/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode) // durum kodları 200-299
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // dotnet add package Newtonsoft.Json
                // using Newtonsoft.Json;
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthor>>(jsonData);
                return View(values);
        }
        return View();
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogid = id;
            return View();
        }
}
}