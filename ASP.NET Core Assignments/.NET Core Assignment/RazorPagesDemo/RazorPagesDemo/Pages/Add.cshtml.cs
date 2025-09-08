using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public string NewItem { get; set; }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NewItem))
            {
                // ✅ Correct static access
                IndexModel.Items.Add(NewItem);
            }

            return RedirectToPage("Index");
        }
    }
}
