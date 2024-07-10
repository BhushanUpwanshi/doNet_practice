using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Repository;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> students = StudentManager.GetStudents();
            ViewData["slist"] = students;
            return View(students);
            //return Json(StudentManager.GetStudents());
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(string Student_Name ,
         string Student_Email ,double Mobile_number, string Student_Address, DateTime admission_date,double fees,string status)
        {
            Student s=new Student();
            s.Student_Name = Student_Name;
            s.Student_Email = Student_Email;
            s.Mobile_number = Mobile_number;
            s.Student_Address = Student_Address;
            s.admission_date = admission_date;
            s.fees = fees;
            s.status = status;

            StudentManager.AddStudent(s);
            return RedirectToAction("GetStudents");
        }
        [HttpGet]
        public IActionResult removeStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult removeStudent(int id)
        {
            StudentManager.removeStudent(id);
            return RedirectToAction("GetStudents");
        }

        //UpdateStudent
        public IActionResult UpdateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateStudent(int Student_ID, string Student_Name,
         string Student_Email, double Mobile_number, string Student_Address, 
         DateTime admission_date, double fees, string status)
        {
            Student s = new Student();
            s.Student_ID = Student_ID;
            s.Student_Name = Student_Name;
            s.Student_Email = Student_Email;
            s.Mobile_number = Mobile_number;
            s.Student_Address = Student_Address;
            s.admission_date = admission_date;
            s.fees = fees;
            s.status = status;

            StudentManager.UpdateStudent(s);
            return RedirectToAction("GetStudents");
        }
        //FindStudent
        [HttpGet]
        public IActionResult FindStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindStudentRes(string status)
        {
            List<Student> sl=StudentManager.FindStudent(status);
            ViewData["sl"] = sl;
            return View(sl);
        }
        [HttpGet]
        public IActionResult SortStudent()
        {
            List<Student> sl = StudentManager.SortStudent();
            ViewData["sl"] = sl;
            return View(sl);
        }
    }
}
