using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Model;
namespace StudentManagementApi.Repository
{
    public class StudentContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        string conString = @"server=localhost;port=3306; user=root;password=Pass@123;database=test;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseMySQL(conString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Student_Id);
                entity.Property(e => e.Student_Name);
                entity.Property(e => e.Student_Email_Id);
                entity.Property(e => e.Mobile_number);
                entity.Property(e => e.Student_address);
                entity.Property(e => e.Admission_date);
                entity.Property(e => e.Fees);
                entity.Property(e => e.Status);
            });
            modelBuilder.Entity<Student>().ToTable("students");
        }
    }
}
