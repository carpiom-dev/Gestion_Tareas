using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_end_prueba.Pages.Shared
{
    public class LayoutModel : PageModel
    {
        public bool IsSessionActive { get; set; }

        public void OnGet()
        {
            IsSessionActive = !string.IsNullOrEmpty(HttpContext.Session.GetString("Token"));
        }
    }
}
