using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace front_end_prueba.Pages
{
    public class EditarTareaModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<EditarTareaModel> _logger;

        public EditarTareaModel(IHttpClientFactory httpClientFactory, ILogger<EditarTareaModel> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [BindProperty]
        public TareaDto Tarea { get; set; } = new();
        public bool IsSessionActive { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            IsSessionActive = !string.IsNullOrEmpty(HttpContext.Session.GetString("Token"));

            var client = _httpClientFactory.CreateClient("ApiClient");
            var token = HttpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login");
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var requestBody = JsonSerializer.Serialize(new { id });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("consultar-task-item-id", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<RespuestaApi<TareaDto>>();
                    if (result != null && result.Respuesta.EsExitosa)
                    {
                        Tarea = result.Resultado!;
                    }
                    else
                    {
                        _logger.LogWarning("No se pudo obtener la tarea.");
                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var token = HttpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login");
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(new
            {
                id = Tarea.Id,
                titulo = Tarea.Titulo,
                descripcion = Tarea.Descripcion,
                fechaVencimiento = Tarea.FechaVencimiento,
                esCompletada = Tarea.EsCompletada
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("actualizar-task-item", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                _logger.LogError($"Error en la actualización: {response.StatusCode}");
            }

            return Page();
        }

        public class RespuestaApi<T>
        {
            public Respuesta Respuesta { get; set; }
            public T Resultado { get; set; }
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
            public DateTime FechaVencimiento { get; set; }
            public bool EsCompletada { get; set; }
        }
    }
}
