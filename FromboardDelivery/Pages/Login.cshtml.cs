using FromboardDelivery.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authentication;

namespace FromboardDelivery.Pages
{
    public class LoginModel : PageModel
    {
        DeliveryContext db;
        [BindProperty]
        public Admin Manager { get; set; } = new();
        public LoginModel(DeliveryContext context)
        {
            db = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl)
        {
            Admin? admin = await db.Admins.FirstOrDefaultAsync(m => m.Email == Manager.Email && m.Password == Manager.Password);
            if (admin is null) return RedirectToPage();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, admin.Name), new Claim(ClaimTypes.Email, admin.Email) };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Redirect(returnUrl ?? "/");
        }
    }
}
