using Student_management.Models;

namespace Student_management.Repositories
{
    public interface IStudentManager
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Student> searchStudent(string status);
        List<Student> SortedStudents();
    }
}
