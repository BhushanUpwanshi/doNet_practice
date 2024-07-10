using StudentManagementApi.Model;

namespace StudentManagementApi.Repository
{
    public class StudentManager
    {
        public static List<Student> GetStudents()
        {
            using (var context = new StudentContext())
            {

                /*var Stds = from std in context.Students select std;
                return Stds.ToList<Student>();*/
                return context.Students.ToList();
            }
            
        }
    }
 }
