using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLiteCRUDDemo.Models;

namespace SQLiteCRUDDemo.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public int studentId { get; set; }

        [BindProperty]
        public string? studentName { get; set; }

        [BindProperty]
        public string? studentGrade { get; set; }

        [BindProperty]
        public string? studentSubject { get; set; }

        
        public void OnGet(int id)
        {
            StudentDBContext context = new StudentDBContext();
            Student stu = context.StudentSet.Where(i => i.Id == id).FirstOrDefault();
            studentId = stu.Id;
            studentName = stu.StudentName;
            studentGrade = stu.StudentGrade;
            studentSubject = stu.StudentSubject;
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            StudentDBContext context = new StudentDBContext();

            Student stu = context.StudentSet.Where(i => i.Id == studentId).FirstOrDefault();
            
            stu.StudentName = studentName;
            stu.StudentGrade = studentGrade;
            stu.StudentSubject = studentSubject;

            context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
