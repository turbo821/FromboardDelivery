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
        public Admin Admin { get; set; } = new();
        public string Message { get; set; } = "";
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
            Admin? admin = await db.Admins.FirstOrDefaultAsync(m => m.Email == Admin.Email && m.Password == Admin.Password);
            if (admin is null)
            {
                Message = $"Почта или пароль неверны";
                return Page();
            }
            else
            {
                Admin = admin;
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, admin.Name??""), new Claim(ClaimTypes.Email, admin.Email) };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(returnUrl ?? "/");
            }

        }
    }
}
