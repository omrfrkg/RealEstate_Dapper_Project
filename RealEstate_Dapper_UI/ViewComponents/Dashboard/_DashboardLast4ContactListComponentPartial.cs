using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ContactDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardLast4ContactListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4ContactListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Contacts/GetLast4Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var contactList = JsonConvert.DeserializeObject<List<Last4ContactResultDto>>(responseData);
                return View(contactList);
            }
            else
            {
                // Handle error response
                
            }
            return View();
        }
    }
    
}
