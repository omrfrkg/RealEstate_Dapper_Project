using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44378/api/Products/GetProductWithSearchList?searchKeyValue={TempData["searchKeyValue"]}&propertyCategoryId={TempData["propertyCategoryId"]}&city={TempData["city"]}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug,int id)
        {
            ViewBag.i = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Products/GetProductByProductID?id="+id);


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44378/api/ProductDetails/GetProductDetailByProductID?id=" + id);

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

                ViewBag.productId = values.productId;
                ViewBag.productTitle = values.title;
                ViewBag.price = values.price;
                ViewBag.city = values.city;
                ViewBag.district = values.district;
                ViewBag.address = values.address;
                ViewBag.type = values.type;
                ViewBag.description = values.description;
                ViewBag.date = values.advertisementDate;
                ViewBag.slugUrl = values.SlugUrl;

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

                string slugFromTitle = CreateSlug(values.title);
                ViewBag.slugUrl = slugFromTitle;

                return View(values);
            }

            return View();
        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // küçük harfe çevir
            title = title.Replace(" ", "-"); // boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9-]", ""); // sadece a-z, 0-9 ve tire karakterlerini bırak
            title = System.Text.RegularExpressions.Regex.Replace(title,@"\s+"," ").Trim();// birden fazla boşluğu tek boşluğa çevir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // boşlukları tire ile değiştir
            return title;
        }
    }
}
