using Microsoft.AspNetCore.Mvc;
using Pract2.Models;
using Pract2.Repository;

namespace Pract2.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> slist = StudentManager.GetStudents();
            ViewData["slist"] = slist;
            return View(slist);
            //return Json(slist);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(int Student_Id, string Student_Name, string Student_Email_Id, double Mobile_number,
            string Student_address, DateTime Admission_date, double Fees, string Status)
        {
            Student std=new Student();
            std.Student_Id = Student_Id;
            std.Student_Name = Student_Name;
            std.Student_Email_Id = Student_Email_Id;
            std.Mobile_number = Mobile_number;
            std.Student_address = Student_address;
            std.Admission_date = Admission_date;
            std.Fees = Fees;
            std.Status = Status;
            StudentManager.AddStudent(std);
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        public IActionResult DeleteStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteStudent(int Student_Id)
        {
            StudentManager.DeleteStudent(Student_Id);
            return RedirectToAction("GetStudents");
        }
        [HttpGet]
        public IActionResult UpdateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStudent(int Student_Id, string Student_Name, string Student_Email_Id, double Mobile_number,
            string Student_address, DateTime Admission_date, double Fees, string Status)
        {
            Student std=new Student();
            std.Student_Id = Student_Id;
            std.Student_Name = Student_Name;
            std.Student_Email_Id = Student_Email_Id;
            std.Mobile_number = Mobile_number;
            std.Student_address = Student_address;
            std.Admission_date = Admission_date;
            std.Fees = Fees;
            std.Status = Status;
            StudentManager.UpdateStudent(std);
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        public IActionResult SortStudent()
        {
            List<Student> slist=StudentManager.Sort();
            ViewData["slist"]= slist;  
            return View(slist);
        }
        [HttpGet]
        public IActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Find(int id)
        {
            return Json (StudentManager.Find(id));
        }
        [HttpGet]
        public IActionResult SearchByStatus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchByStatusRes(string status)
        {
            List<Student> slist = StudentManager.SearchByStatus(status);
            ViewData["slist"] = slist;
            return View(slist);
        }
    }
}
