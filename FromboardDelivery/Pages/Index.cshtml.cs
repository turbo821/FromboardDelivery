using FromboardDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FromboardDelivery.Pages
{
    public class IndexModel : PageModel
    {
        private DeliveryContext db;
        [BindProperty]
        public Calculation Calculation { get; set; } = new();
        [BindProperty]
        public Question Question { get; set; } = new();
        public string Message { get; private set; } = "Добавление товара";

        public IndexModel(DeliveryContext context)
        {
            db = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostCalculation()
        {
            db.Calculations.Add(Calculation);
            await db.SaveChangesAsync();
            Message = $"Расчет доставки для {Calculation.Name}({Calculation.Email}): Регион: {Calculation.DeliveryRegion} Телефон: {Calculation.PhoneNumber} Id: {Calculation.Id}";
            return Page();
        }
        public async Task<IActionResult> OnPostQuestion()
        {
            db.Questions.Add(Question);
            await db.SaveChangesAsync();
            Message = $"Заявка для {Question.Name}({Question.Email}): Тема: {Question.Subject}";
            return Page();
        }
    }
}
