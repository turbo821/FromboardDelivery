using FromboardDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FromboardDelivery.Pages
{
    public class IndexModel : PageModel
    {
        private DeliveryContext db;
        public bool SendCalculation { get; set; }
        public bool SendQuestion { get; set; }
        [BindProperty]
        public Calculation Calculation { get; set; } = new();
        [BindProperty]
        public Question Question { get; set; } = new();

        public IndexModel(DeliveryContext context)
        {
            db = context;
        }
        public IActionResult OnGet(bool? sendCalculation, bool? sendQuestion)
        {
            SendCalculation = sendCalculation ?? false;
            SendQuestion = sendQuestion ?? false;

            return Page();
        }
        public async Task<IActionResult> OnPostCalculation()
        {
            try
            {
                db.Calculations.Add(Calculation);
                await db.SaveChangesAsync();
                SendCalculation = true;
            }
            catch (Exception ex)
            {
                SendCalculation = false;
                Console.WriteLine(ex.Message);
            }
            return RedirectToPage(new { sendCalculation = SendCalculation });
        }
        public async Task<IActionResult> OnPostQuestion()
        {
            try
            {
                db.Questions.Add(Question);
                await db.SaveChangesAsync();
                SendQuestion = true;
            }
            catch (Exception ex)
            {
                SendQuestion = false;
                Console.WriteLine(ex.Message);
            }
            return RedirectToPage(new { sendQuestion = SendQuestion });
        }
    }
}
