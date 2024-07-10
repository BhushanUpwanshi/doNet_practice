using Microsoft.AspNetCore.Mvc;
using Student_management.Models;
using Student_management.Repositories;

namespace Student_management.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager)
        {
            this._studentManager = studentManager;
        }
        public IActionResult GetStudents()
        {
            List<Student> students = _studentManager.GetAllStudents();
            ViewData["students"]=students;
            return View(students);
        }
        [HttpGet]
        public IActionResult AddStudent() { return View(); }
        [HttpPost]
        public IActionResult AddStudent(int id, string name,string email,double number,string address,DateTime date,double fees,string Status)
        {
            Student std=new Student();
            std.Student_Id = id;
            std.Student_Name = name;
            std.Student_Email_Id = email;
            std.Mobile_number = number;
            std.Student_address = address;
            std.Admission_date = date;
            std.Fees = fees;
            std.Status = Status;
            _studentManager.AddStudent(std);

            return RedirectToAction("Getstudents");
        }
        [HttpGet]
        public IActionResult UpdateStudent() { return View(); }
        [HttpPost]
        public IActionResult UpdateStudent(int id, string name, string email, double number, string address, DateTime date, double fees, string Status)
        {
            Student std = new Student();
            std.Student_Id = id;
            std.Student_Name = name;
            std.Student_Email_Id = email;
            std.Mobile_number = number;
            std.Student_address = address;
            std.Admission_date = date;
            std.Fees = fees;
            std.Status = Status;
            _studentManager.UpdateStudent(std);

            return RedirectToAction("Getstudents");
        }
        [HttpGet]
        public IActionResult DeleteStudent() { return View(); }

        [HttpPost]
        public IActionResult DeleteStudent(int id) {
            _studentManager.DeleteStudent(id);
            return RedirectToAction("Getstudents");
        }
        [HttpGet]
        public IActionResult SearchStudent() { return View(); }
        [HttpPost]
        public IActionResult SearchStudentDisplay(String status) { 
            List<Student> students=_studentManager.searchStudent(status);
            if (students != null) {
                ViewData["Students"] = students;
                return View(students);
            }
            else {
                return RedirectToAction("Getstudents");
            }
        }
        /*[HttpGet]
        public IActionResult SortedStudents(int id) { return View(); }*/

        [HttpGet]
        public IActionResult SortedStudents()
        {
            List<Student> students= _studentManager.SortedStudents();
            ViewData["sorted"] = students;
            return View(students);
        }
    }
}
