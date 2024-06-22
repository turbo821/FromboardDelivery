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
        public string Message { get; private set; } = "���������� ������";

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
            Message = $"������ �������� ��� {Calculation.Name}({Calculation.Email}): ������: {Calculation.DeliveryRegion} �������: {Calculation.PhoneNumber} Id: {Calculation.Id}";
            return Page();
        }
        public async Task<IActionResult> OnPostQuestion()
        {
            db.Questions.Add(Question);
            await db.SaveChangesAsync();
            Message = $"������ ��� {Question.Name}({Question.Email}): ����: {Question.Subject}";
            return Page();
        }
    }
}
