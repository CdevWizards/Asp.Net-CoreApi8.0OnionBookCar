using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync("http://localhost:5204/api/Blog");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthor>>(jsonData);
                return View(values);
            }
            return View();
    }
    [HttpGet]
    public ActionResult CreateBlog()
    {
        return View();
    }
    [HttpPost]
    public async Task <IActionResult> CreateBlog(CreateBlogDto createBlogDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBlogDto);
        StringContent stringContent = new StringContent (jsonData, Encoding.UTF8,"application/json");
        var responseMessage = await client.PostAsync("http://localhost:5204/api/Blog/GetAllBlogsWithAuthorList", stringContent);
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> RemoveBlog(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage =await client.DeleteAsync($"http://localhost:5204/api/Blog/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateBlog(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5204/api/Blog/{id}");
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
            return View(values);
        }
        return View();
    }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage=await client.PutAsync("http://localhost:5204/api/Blog/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
            return RedirectToAction("Index");
            }
              return View();      
        }
    }
}