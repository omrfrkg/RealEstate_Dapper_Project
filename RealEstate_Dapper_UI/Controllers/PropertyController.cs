﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Products/ProducListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Products/GetProductByProductID?id="+id);


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44378/api/ProductDetails/GetProductDetailByProductID?id=" + id);

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                ViewBag.productTitle = values.title;
                ViewBag.price = values.price;
                ViewBag.city = values.city;
                ViewBag.district = values.district;
                ViewBag.address = values.address;
                ViewBag.type = values.type;
                ViewBag.description = values.description;
                ViewBag.productId = values.productId;
                ViewBag.date = values.advertisementDate;


                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);
                ViewBag.bathCount = values2.BathCount;

                
                DateTime date1 = DateTime.Now;
                DateTime date2 = values.advertisementDate;

                TimeSpan timeSpan = date1 - date2;
                int month = timeSpan.Days;

                ViewBag.dateDiff = month / 30;

                ViewBag.bedCount = values2.BedRoomCount;
                ViewBag.size = values2.ProductSize;
                ViewBag.roomCount = values2.RoomCount;
                ViewBag.garageSize = values2.GarageSize;
                ViewBag.buildYear = values2.BuildYear;
                ViewBag.location = values2.Location;
                ViewBag.videoUrl = values2.VideoUrl;


                return View(values);
            }
            return View();
        }
    }
}
