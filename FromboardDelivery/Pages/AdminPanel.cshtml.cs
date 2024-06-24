using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FromboardDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FromboardDelivery.Pages
{
    public class AdminPanelModel : PageModel
    {
        DeliveryContext db;
        public List<Calculation> Calculations { get; set; } = new();
        public List<Question> Questions { get; set; } = new();

        public AdminPanelModel(DeliveryContext context)
        {
            db = context;
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
                Console.WriteLine($"Äëÿ {calculation.Email}: {message}");
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostQuestionSendAsync(Guid id, string message)
        {
            Question? question = await db.Questions.FindAsync(id);
            // send message in email
            if (question != null)
            {
                Console.WriteLine($"Äëÿ {question.Email}: {message}");
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
    }
}
