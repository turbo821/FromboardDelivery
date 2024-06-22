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

        public void OnPostCalculation()
        {
                Calculations = db.Calculations.AsNoTracking().ToList();

        }
        public void OnPostQuestion()
        {
                Questions = db.Questions.AsNoTracking().ToList();

        }
    }
}
