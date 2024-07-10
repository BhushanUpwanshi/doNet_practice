using Org.BouncyCastle.Tls;
using StudentManagement.Models;

namespace StudentManagement.Repository
{
    public class StudentManager
    {
        public static List<Student> GetStudents()
        {
            using (var context = new StudentContext())
            {
                var slist = from stds in context.Students select stds;
                return slist.ToList();
            }

        }
        public static void AddStudent(Student sts)
        {
            using (var context = new StudentContext())
            {
                context.Students.Add(sts);
                context.SaveChanges();
            }
        }
        public static void removeStudent(int id)
        {
            using(var context = new StudentContext())
            {
                Console.WriteLine(context.Students.Find(id));
                context.Students.Remove(context.Students.Find(id));
                context.SaveChanges();
            }
        }
        public static void UpdateStudent(Student sts)
        {
            using( var context = new StudentContext())
            {
                context.Students.Update(sts);
                context.SaveChanges();
            }
        }
        public static List<Student> FindStudent(string status)
        {
            using ( var context = new StudentContext())
            {
                var sl = from stds in context.Students where stds.status == status select stds;
                return sl.ToList<Student>();
            }
        }
        public static List<Student> SortStudent()
        {
            using(var context=new StudentContext())
            {
                var sl = from s in context.Students orderby s.admission_date descending select s;
                return sl.ToList<Student>();
            }
        }
    }
}
