using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FromboardDelivery.Models;
using Microsoft.EntityFrameworkCore;
using FromboardDelivery.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace FromboardDelivery.Pages
{
    [Authorize]
    public class AdminPanelModel : PageModel
    {
        DeliveryContext db;
        IEmailSending emailSender;
        public List<Calculation> Calculations { get; set; } = new();
        public List<Question> Questions { get; set; } = new();

        public AdminPanelModel(DeliveryContext context, IEmailSending sender)
        {
            db = context;
            emailSender = sender;
        }

        public IActionResult OnGet()
        {
            Calculations = db.Calculations.AsNoTracking().ToList();
            Questions = db.Questions.AsNoTracking().ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostCalculationSendAsync(Guid id, string message)
        {
            Calculation? calculation = await db.Calculations.FindAsync(id);
            // send message in email
            if (calculation != null)
            {
                
                await emailSender.SendAsync(calculation, "������ ��������", $"{calculation.Name} ������������, �� ����������� ���� ������ � ��������� ������: {message}");
                Console.WriteLine($"��� {calculation.Email}: {message}");
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostQuestionSendAsync(Guid id, string message)
        {
            Question? question = await db.Questions.FindAsync(id);
            // send message in email
            if (question != null)
            {
                await emailSender.SendAsync(question, "����� �� ������", $"{question.Name} ������������,\n{message}");
                Console.WriteLine($"��� {question.Email}: {message}");
                Console.WriteLine($"��� {question.Email}: {message}");
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCalculationDeleteAsync(Guid id)
        {
            Calculation? calculation = await db.Calculations.FindAsync(id);
            if(calculation != null)
            {
                db.Calculations.Remove(calculation);
                await db.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostQuestionDeleteAsync(Guid id)
        {
            Question? question = await db.Questions.FindAsync(id);
            if (question != null)
            {
                db.Questions.Remove(question);
                await db.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("Login");
        }
    }
}
