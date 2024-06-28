using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FromboardDelivery.Models;
using Microsoft.EntityFrameworkCore;
using FromboardDelivery.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
namespace FromboardDelivery.Pages
{
    [Authorize]
    public class AdminPanelModel : PageModel
    {
        DeliveryContext db;
        IEmailSending emailSender;
        public bool Sended { get; set; } = false;
        public bool Deleted { get; set; } = false;
        public GroupViewModel CalculationGroup { get; set; } = null!;
        public GroupViewModel QuestionsGroup { get; set; } = null!;
        public List<Calculation> Calculations { get; set; } = new();
        public List<Question> Questions { get; set; } = new();
        
        [Required(ErrorMessage = "Введите сообщение")]
        [BindProperty]
        public string? Message { get; set; }
        public AdminPanelModel(DeliveryContext context, IEmailSending sender)
        {
            db = context;
            emailSender = sender;
        }

        public async Task<IActionResult> OnGet(bool? deleted, bool? sended, int calculationPage = 1, int questionPage = 1)
        {
            Sended = sended ?? false;
            Deleted = deleted ?? false;

            //Calculations = db.Calculations.AsNoTracking().ToList();
            //Questions = db.Questions.AsNoTracking().ToList();

            int pageSize = 6;

            IQueryable<Calculation> calculations = db.Calculations.AsNoTracking();
            IQueryable<Question> questions = db.Questions.AsNoTracking();

            var countCalculation = await calculations.CountAsync();
            var countQuestion = await questions.CountAsync();

            Calculations = await calculations.Skip((calculationPage - 1) * pageSize).Take(pageSize).ToListAsync();
            Questions = await questions.Skip((questionPage - 1) * pageSize).Take(pageSize).ToListAsync();

            CalculationGroup = new GroupViewModel(countCalculation, calculationPage, pageSize);
            QuestionsGroup = new GroupViewModel(countQuestion, questionPage, pageSize);
            return Page();
        }

        public async Task<IActionResult> OnPostCalculationSendAsync(Guid id)
        {
            Calculation? calculation = await db.Calculations.FindAsync(id);
            // send message in email
            if (calculation != null)
            {
               // await emailSender.SendAsync(calculation, "Расчет доставки", $"{calculation.Name} здравствуйте, мы просмотрели вашу заявку и составили расчет: {Message}");
                Console.WriteLine($"Для {calculation.Email}: {Message}");
                Sended = true;
            }
            return RedirectToPage(routeValues: new { sended = Sended }, pageName: null, pageHandler: null, fragment: "calculation-data");
        }

        public async Task<IActionResult> OnPostQuestionSendAsync(Guid id)
        {
            Question? question = await db.Questions.FindAsync(id);
            // send message in email
            if (question != null)
            {
                //await emailSender.SendAsync(question, "Ответ на заявку", $"{question.Name} здравствуйте,\n{Message}");
                Console.WriteLine($"Для {question.Email}: {Message}");
                Sended = true;
            }
            return RedirectToPage(routeValues: new { sended = Sended }, pageName: "AdminPanel", pageHandler: "Get", fragment: "question-data");
        }

        public async Task<IActionResult> OnPostCalculationDeleteAsync(Guid id)
        {
            Calculation? calculation = await db.Calculations.FindAsync(id);
            if(calculation != null)
            {
                db.Calculations.Remove(calculation);
                await db.SaveChangesAsync();
                Deleted = true;
            }
            return RedirectToPage(routeValues: new { deleted = Deleted }, pageName: "AdminPanel", pageHandler: "Get", fragment: "calculation-data");
        }

        public async Task<IActionResult> OnPostQuestionDeleteAsync(Guid id)
        {
            Question? question = await db.Questions.FindAsync(id);
            if (question != null)
            {
                db.Questions.Remove(question);
                await db.SaveChangesAsync();
                Deleted = true;
            }
            return RedirectToPage(routeValues: new { deleted = Deleted }, pageName: "AdminPanel", pageHandler: "Get", fragment: "question-data");
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("Login");
        }
    }
}
