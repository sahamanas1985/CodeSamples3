using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteCRUDDemo.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? StudentGrade { get; set; }
        public string? StudentSubject { get; set; }

    }
}
