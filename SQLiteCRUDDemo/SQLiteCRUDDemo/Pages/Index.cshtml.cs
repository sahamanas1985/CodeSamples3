using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLiteCRUDDemo.Models;

namespace SQLiteCRUDDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public List<Student> Students { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //Get list of Students from DB
            StudentDBContext context = new StudentDBContext();
            Students = context.StudentSet.ToList();

        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPostDeleteStudent(int studentid)
        {
            StudentDBContext context = new StudentDBContext();
            Student stu = context.StudentSet.Where(i => i.Id == studentid).FirstOrDefault();
            context.Remove(stu);
            context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}