using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Student_management.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Student_management.Repositories
{
    public class StudentManager:IStudentManager
    {
        public List<Student> GetAllStudents()
        {
            using (var context = new StudentDbContext()) {
                var students = from stud in context.Students select stud;
                return students.ToList<Student>();
            }
        }
        public void AddStudent(Student student)
        {
            using(var context=new StudentDbContext())
            {
                try
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public void UpdateStudent(Student student)
        {
            using (var context = new StudentDbContext())
            {
                var std = context.Students.Find(student.Student_Id);
                std.Student_Id = student.Student_Id;
                std.Student_Name = student.Student_Name;
                std.Student_Email_Id = student.Student_Email_Id;
                std.Mobile_number = student.Mobile_number;
                std.Student_address = student.Student_address;
                std.Admission_date = student.Admission_date;
                std.Fees = student.Fees;
                std.Status = student.Status;
                context.SaveChanges();
            }
        }
        public void DeleteStudent(int id)
        {
            using (var context = new StudentDbContext())
            {
                context.Students.Remove(context.Students.Find(id));
                context.SaveChanges();
            }
        }

        public List<Student> searchStudent(string status)
        {
            using(var context=new StudentDbContext())
            {
                
                var students= from std in context.Students  where std.Status == status select std;
                return students.ToList();
            }

        }
        public List<Student> SortedStudents()
        {
            using(var context=new StudentDbContext())
            {
                var Stds=from std in context.Students orderby std.Status select std;
                return Stds.ToList();
            }
            
        }
    }
}
