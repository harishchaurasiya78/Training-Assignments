using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class IndexModel : PageModel
    {
        // ✅ Static list shared between pages
        public static List<string> Items { get; set; } = new List<string>();

        public void OnGet()
        {
            // Nothing needed, Items is static
        }
    }
}
