using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
namespace StudentManagement.Repository
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStrign = @"server=localhost;port=3306;user=root;password=Pass@123;database=temp1;";
            optionsBuilder.UseMySQL(conStrign);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e=>e.Student_ID);
                entity.Property(e => e.Student_Name);
                entity.Property(e=>e.Student_Email);
                entity.Property(e=>e.Mobile_number);
                entity.Property(e=>e.Student_Address);
                entity.Property(e=>e.admission_date);
                entity.Property(e=>e.fees);
                entity.Property(e=>e.status);
            });
            modelBuilder.Entity<Student>().ToTable("students");

        }
    }
}
