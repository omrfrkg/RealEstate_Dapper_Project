using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44378/api/Logins", content);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (tokenModel != null && !string.IsNullOrEmpty(tokenModel.Token))
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(tokenModel.Token);
                        var claims = token.Claims.ToList();

                        claims.Add(new Claim("realestatetoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Geçersiz token alındı.");
                    }
                }
                catch (JsonException ex)
                {
                    // JSON parse hatası
                    ModelState.AddModelError("", "Sunucudan geçersiz bir yanıt alındı.");
                    // Hata detaylarını loglayabilirsiniz
                    Console.WriteLine("JSON Hatası: " + ex.Message);
                }
            }
            else
            {
                // Hata durumu (örneğin, 401 Unauthorized)
                var errorContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var errorModel = JsonSerializer.Deserialize<ErrorResponseModel>(errorContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    ModelState.AddModelError("", errorModel?.Error ?? "Giriş işlemi başarısız.");
                }
                catch
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                }
            }

            return View();
        }

        // Hata yanıtı için model
        public class ErrorResponseModel
        {
            public string Error { get; set; }
        }
    }
}
