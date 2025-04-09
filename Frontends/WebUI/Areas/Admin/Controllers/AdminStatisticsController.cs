using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticsDtos;

namespace WebUI.Areas.Admin.Controllers
{
     [Area("Admin")]
    public class AdminStatisticsController : Controller
    {
     private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region Araç İstatistik
            var responseMessage=await client.GetAsync("http://localhost:5204/api/Statistics/GetCarCount");
            if(responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0,101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.v1= v1;
                //return View();
            }
            #endregion
            #region Lokasyon İstatistik
             var responseMessage2=await client.GetAsync("http://localhost:5204/api/Statistics/GetLocationCount");
            if(responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = random.Next(0,101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2=JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
                ViewBag.locationCountRandom= locationCountRandom;
                //return View();
            }
            #endregion
            #region Yazar Sayısı
              var responseMessage3=await client.GetAsync("http://localhost:5204/api/Statistics/GetAuthorCount");
            if(responseMessage3.IsSuccessStatusCode)
            {
                int AuthorCountRandom = random.Next(0,101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3=JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.AuthorCount = values3.AuthorCount;
                ViewBag.AuthorCountRandom= AuthorCountRandom;
                //return View();
            }
            #endregion
            #region  Blog Sayısı
             var responseMessage4=await client.GetAsync("http://localhost:5204/api/Statistics/GetBlogCount");
            if(responseMessage4.IsSuccessStatusCode)
            {
                int BlogCountRandom = random.Next(0,101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4=JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.BlogCount = values4.BlogCount;
                ViewBag.BlogCountRandom= BlogCountRandom;
                //return View();
            }
            #endregion 
            #region  Brand Sayısı
            var responseMessage5=await client.GetAsync("http://localhost:5204/api/Statistics/GetBrandCount");
            if(responseMessage5.IsSuccessStatusCode)
            {
                int BrandCountRandom = random.Next(0,101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5=JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.BrandCount = values5.BrandCount;
                ViewBag.BrandCountRandom= BrandCountRandom;
                //return View();
            }
            #endregion 
            #region Günlük Ücret
            var responseMessage6 = await client.GetAsync("http://localhost:5204/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgRentPriceForDailyRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.avgRentPriceForDaily = values6.avgPriceForDaily.ToString("0.00"); ;
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }
            #endregion
            #region Haftalık Ücret
             var responseMessage7 = await client.GetAsync("http://localhost:5204/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int avgRentPriceForWeeklyRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = values7.avgPriceForWeekly.ToString("0.00"); ;
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            }
            #endregion
            #region Aylık Ücret
              var responseMessage8 = await client.GetAsync("http://localhost:5204/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int avgRentPriceForMonthlyRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.avgRentPriceForMonthly = values8.avgPriceForMonthly.ToString("0.00"); ;
                ViewBag.avgRentPriceForMonthlyRandom = avgRentPriceForMonthlyRandom;
            }
            #endregion
            #region Vites
            var responseMessage9 = await client.GetAsync("http://localhost:5204/api/Statistics/GetCarCountByTransmissonIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountByTransmissonIsAutoRandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountByTransmissonIsAuto = values9.carCountByTransmissonIsAuto;//.ToString("0.00"); ;
                ViewBag.avgRentPriceForMonthlyRandom = carCountByTransmissonIsAutoRandom;
            }
            #endregion
            #region Max Araç Markası 
              var responseMessage10 = await client.GetAsync("http://localhost:5204/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int brandNameByMaxCarRandom = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.brandNameByMaxCar = values10.brandNameByMaxCar;//.ToString("0.00"); ;
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
            }
            #endregion
            #region KM 1000 Den Düşük Araçlar
              var responseMessage12 = await client.GetAsync("http://localhost:5204/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carCountByKmSmallerThen1000Random = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.CarCountByKmSmallerThen1000 = values12.carCountByKmSmallerThen1000;//.ToString("0.00"); ;
                ViewBag.carCountByKmSmallerThen1000Random = carCountByKmSmallerThen1000Random;
            }
            #endregion
             #region Dizel araçlar
              var responseMessage13 = await client.GetAsync("http://localhost:5204/api/Statistics/GetCarCountByFuelGasolineorDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineorDieselRandom = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.carCountByFuelGasolineorDiesel = values13.carCountByFuelGasolineorDiesel;//.ToString("0.00"); ;
                ViewBag.carCountByFuelGasolineorDieselRandom = carCountByFuelGasolineorDieselRandom;
            }
            #endregion
            #region Elektrikli araçlar
              var responseMessage14 = await client.GetAsync("http://localhost:5204/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int carCountByFuelElectricRandom = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.carCountByFuelElectric = values14.carCountByFuelElectric;//.ToString("0.00"); ;
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            }
            #endregion
            #region Günlük Max Ücretli Araç
            var responseMessage15 = await client.GetAsync("http://localhost:5204/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values15.carBrandAndModelByRentPriceDailyMax;//.ToString("0.00"); ;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMaxRandom;
            }
            #endregion
            #region Günlük Min Ücretli Araç
            var responseMessage16 = await client.GetAsync("http://localhost:5204/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
                var jsonData15 = await responseMessage16.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values15.carBrandAndModelByRentPriceDailyMin;//.ToString("0.00"); ;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMinRandom;
            }
            #endregion
            #region Blog Say
            var responseMessage17 = await client.GetAsync("http://localhost:5204/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage17.IsSuccessStatusCode)
            {
                int blogTitleByMaxBlogCommentRandom = random.Next(0, 101);
                var jsonData17 = await responseMessage17.Content.ReadAsStringAsync();
                var values17 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData17);
                ViewBag.blogTitleByMaxBlogComment = values17.blogTitleByMaxBlogComment;//.ToString("0.00"); ;
                ViewBag.blogTitleByMaxBlogCommentRandom = blogTitleByMaxBlogCommentRandom;
            }
            #endregion
            return View();

    }
}
}