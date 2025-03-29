using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminServiceController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public AdminServiceController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5204/api/Service");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult CreateService()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createServiceDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5204/api/Service", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminService");
			}
			return View();
		}

		public async Task<IActionResult> RemoveService(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5204/api/Service/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminService");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateService(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5204/api/Service/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateServiceDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5204/api/Service/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}