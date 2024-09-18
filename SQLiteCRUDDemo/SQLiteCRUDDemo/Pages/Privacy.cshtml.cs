using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLiteCRUDDemo.Models;

namespace SQLiteCRUDDemo.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        [BindProperty]
        public string? studentName { get; set; }

        [BindProperty]
        public string? studentGrade { get; set; }

        [BindProperty]
        public string? studentSubject { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            StudentDBContext context = new StudentDBContext();
            context.Add(new Student
            {
                StudentName = studentName,
                StudentGrade = studentGrade,
                StudentSubject = studentSubject
            });

            context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}