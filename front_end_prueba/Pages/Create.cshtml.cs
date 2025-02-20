using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading;
using static front_end_prueba.Pages.IndexModel;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;

namespace front_end_prueba.Pages;

public class CreateModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly ILogger<IndexModel> _logger;


    public CreateModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [BindProperty]
    public CrearTaskItem Tarea { get; set; }
    public bool IsSessionActive { get; set; }


    public async Task<IActionResult> OnPostAsync()
    {
        IsSessionActive = !string.IsNullOrEmpty(HttpContext.Session.GetString("Token"));

        if (HttpContext.Session == null)
        {
            _logger.LogError("La sesión no está configurada.");
            return RedirectToPage("/Login");
        }

        var token = HttpContext.Session.GetString("Token");

        if (string.IsNullOrEmpty(token))
        {
            _logger.LogWarning("No se encontró el token en la sesión.");
            return RedirectToPage("/Login");
        }

        var client = _httpClientFactory.CreateClient("ApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        try
        {
            var json = JsonSerializer.Serialize(Tarea);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("crear-task-item", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                _logger.LogError("Error al crear la tarea: {StatusCode}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            return RedirectToPage("Login");
        }

        return Page();
    }

    public class CrearTaskItem
    {
        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public required bool EsCompletada { get; set; }
    }
}

