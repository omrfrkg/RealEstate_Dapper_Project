using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public StatisticController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region İstatistik - 1
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion
            #region İstatistik - 2
            var client2 = _clientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44378/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion
            #region İstatistik - 3
            var client3 = _clientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44378/api/Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;
            #endregion
            #region İstatistik - 4
            var client4 = _clientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44378/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = (decimal.Parse(jsonData4.Replace(".", "")) / 1000000m).ToString("N2");
            #endregion
            #region İstatistik - 5
            var client5 = _clientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44378/api/Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = (decimal.Parse(jsonData5.Replace(".", "")) / 1000000m).ToString("N2");
            #endregion
            #region İstatistik - 6
            var client6 = _clientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44378/api/Statistics/AverageRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.averageRoomCount = jsonData6;
            #endregion
            #region İstatistik - 7
            var client7 = _clientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44378/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData7;
            #endregion
            #region İstatistik - 8
            var client8 = _clientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44378/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData8;
            #endregion
            #region İstatistik - 9
            var client9 = _clientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44378/api/Statistics/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData9;
            #endregion
            #region İstatistik - 10
            var client10 = _clientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync("https://localhost:44378/api/Statistics/DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData10;
            #endregion
            #region İstatistik - 11
            var client11 = _clientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync("https://localhost:44378/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData11;
            #endregion
            #region İstatistik - 12
            var client12 = _clientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync("https://localhost:44378/api/Statistics/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.lastProductPrice = (decimal.Parse(jsonData12.Replace(".", "")) / 100m).ToString("N2");

            #endregion
            #region İstatistik - 13
            var client13 = _clientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync("https://localhost:44378/api/Statistics/NewestBuldingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            int newesBuildYear = int.Parse(jsonData13);
            int currentYear = DateTime.Now.Year;
            int yearDifference = currentYear - newesBuildYear;
            ViewBag.newestBuildingYear = yearDifference;
            #endregion
            #region İstatistik - 14
            var client14 = _clientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync("https://localhost:44378/api/Statistics/OldestBuldingYear");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            int oldestBuildYear = int.Parse(jsonData14);
            int yearDifference2 = currentYear - oldestBuildYear;
            ViewBag.oldestBuldingYear = yearDifference2;
            #endregion
            #region İstatistik - 15
            var client15 = _clientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:44378/api/Statistics/PassiveCategoryCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCount = jsonData15;
            #endregion
            #region İstatistik - 16
            var client16 = _clientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:44378/api/Statistics/ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData16;
            #endregion
            return View();
        }
    }
}
