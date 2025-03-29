using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CommentDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {

       private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v=id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync($"http://localhost:5204/api/Comments/CommentListByBlog?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
    }
    }
}