using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using front_end_prueba.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace front_end_prueba.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(IHttpClientFactory httpClientFactory, ILogger<LoginModel> logger)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
            _logger = logger;
        }

        [BindProperty]
        public UserLoginDto User { get; set; } = new();

        public string ErrorMessage { get; set; } = "";
        public bool IsSessionActive { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var json = JsonSerializer.Serialize(User);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("iniciar-sesion", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonSerializer.Deserialize<LoginResponseDto>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (loginResponse != null && loginResponse.Respuesta.EsExitosa && loginResponse.Resultado.Jwt != null)
                {
                    var token = loginResponse.Resultado.Jwt.AccessToken;

                    HttpContext.Session.SetString("Token", token);
                    IsSessionActive = !string.IsNullOrEmpty(token);

                    return RedirectToPage("/Index");
                }
            }

            ErrorMessage = "Credenciales incorrectas o error en la autenticación.";
            return Page();
        }


    }
}
