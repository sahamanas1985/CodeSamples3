using Microsoft.EntityFrameworkCore;

namespace SQLiteCRUDDemo.Models
{
    public class StudentDBContext : DbContext
    {
        string DbPath = @"C:\Manas\Code Samples\Year_3\SQLiteCRUDDemo\SQLiteCRUDDemo\DB\Students.db";
        public DbSet<Student> StudentSet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=" + DbPath);
    }
}

//  Add-Migration InitialCreate
//  update-database