using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace front_end_prueba.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;


    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public List<TareaDto> Tareas { get; set; } = new();
    public bool IsSessionActive { get; set; }


    public async Task<IActionResult> OnGetAsync()
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
            var response = await client.PostAsync("consultar-task-items", new StringContent("{}", Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RespuestaApi<List<TareaDto>>>();

                if (result != null && result.Respuesta.EsExitosa)
                {
                    Tareas = result.Resultados ?? new List<TareaDto>();
                }
                else
                {
                    _logger.LogWarning("La respuesta de la API no fue exitosa: {Mensaje}", result?.Respuesta.Mensaje);
                }
            }
            else
            {
                _logger.LogError("Error en la solicitud: {StatusCode}", response.StatusCode);
            }
        }
        catch (JsonException ex)
        {
            return RedirectToPage("Login");
        }
        catch (HttpRequestException ex)
        {
            return RedirectToPage("Login");
        }

        return Page();
    }


    public async Task<IActionResult> OnPostEliminarAsync(int id)
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
            var json = JsonSerializer.Serialize(new { id });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("eliminar-task-item", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                _logger.LogError("Error al eliminar la tarea con ID {Id}: {StatusCode}", id, response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            return RedirectToPage("Login");
        }

        return Page();
    }

    public class RespuestaApi<T>
    {
        public Respuesta Respuesta { get; set; }
        public T Resultados { get; set; }
    }

    public class Respuesta
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public bool EsExitosa { get; set; }
        public bool ExisteExcepcion { get; set; }
    }

    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }
        public bool Activo { get; set; }
    }
}
