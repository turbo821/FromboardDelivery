using FromboardDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FromboardDelivery.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Manager Manager { get; set; } = new();
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
