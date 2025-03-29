using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.TestimonialDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTestimonialController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		public AdminTestimonialController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5204/api/Testimonial");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult CreateTestimonial()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5204/api/Testimonial", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminTestimonial");
			}
			return View();
		}

		public async Task<IActionResult> RemoveTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5204/api/Testimonial/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminTestimonial");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateTestimonial(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5204/api/Testimonial/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5204/api/Testimonial/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}