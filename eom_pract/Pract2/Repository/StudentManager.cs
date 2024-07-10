using Pract2.Models;

namespace Pract2.Repository
{
    public class StudentManager
    {
        public static List<Student> GetStudents()
        {
            using (var context=new StudentContext())
            {
                var slist = from std in context.Students select std;
                return slist.ToList<Student>();
            }
        }
        public static void AddStudent(Student student)
        {
            using (var context = new StudentContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
        public static void DeleteStudent(int id)
        {
            using(var context = new StudentContext())
            {
                context.Students.Remove(context.Students.Find(id));
                context.SaveChanges();
            }
        }
        public static void UpdateStudent(Student student)
        {
            using( var context = new StudentContext())
            {
                context.Students.Update(student);
                context.SaveChanges();
            }
        }
        public static List<Student> Sort()
        {
            using(var context=new StudentContext())
            {
                var slist = from std in context.Students orderby std.Status select std;
                return slist.ToList<Student>();
            }
        }
        public static Object Find(int id)
        {
            using(var context=new StudentContext())
            {
                /*var stud=from std in context.Students where std.Student_Id == id select std;
                return (Student)stud;*/
               return context.Students.Find(id);
            }
        }
        public static List<Student> SearchByStatus(string stat)
        {
            using (var context = new StudentContext())
            {
                var slist = from std in context.Students where std.Status == stat select std;
                return slist.ToList<Student>();
            }
        }
    }
}
