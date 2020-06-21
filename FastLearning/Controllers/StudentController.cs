using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FastLearning.Models;
using FastLearning.ServiceRepository;
using FastLearning.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FastLearning.Controllers
{
   
    public class StudentController : Controller
    {
        private readonly IStudent _student;

        private readonly IWebHostEnvironment hostEnvironment;

        public StudentController(IWebHostEnvironment host, IStudent stud)
        {
            hostEnvironment = host;
            _student = stud;
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult List()
        {
            return View(_student.Students);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(StudentViewModel students)
        {
            

            if (ModelState.IsValid)
            {
                string UniqueFileName = null;
                if (students.Photo != null)
                {
                    
                        string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "images");
                        UniqueFileName = Guid.NewGuid().ToString() + "_" + students.Photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, UniqueFileName);
                        students.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    

                }

                Student stud = new Student()
                {
                    Surname = students.Surname,
                    Othernames = students.Othernames,
                    PhoneNo = students.PhoneNo,
                    Email = students.Email,
                    Address = students.Address,
                    City = students.City,
                    Age = students.Age,
                    State = students.State,
                    Passport = UniqueFileName,
                };

                
                _student.AddStudent(stud);
               
                return RedirectToAction(nameof(Create), new { IsSuccess = true });
            }
            else
            {
                
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteConfirm(int ID)
        {

            Student stud = _student.GetStudent(ID);
            if (stud == null)
            {
                //Error message
                return RedirectToAction("List");
            }
            return View(stud);
        }

        [HttpPost]

        public IActionResult Delete(int ID)
        {
            var stud = _student.Delete(ID);
            return View("Deleted", stud);

        }

        public IActionResult Deleted()
        {
            return View();
        }

        public IActionResult Details(int ID)
        {
            Student stud = _student.GetStudent(ID);
            return View(stud);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            Student stud = _student.GetStudent(ID);
            //Employee emp = _employee.GetEmployee(ID);
            return View(stud);
        }

        [HttpPost]
        public ActionResult Edit(Student stud)
        {
            //write code to update student 
            _student.SaveStudent(stud);
            //return RedirectToAction("Confirmation",studs);
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {

            return View();
        }


        [HttpPost]
        //public IActionResult Search(string surname)
        //{
        //    var stud = _student.Search(surname);
        //    return View("SearchOutput", stud);
        //}



        [HttpPost]
        public IActionResult Search(string surname)
        {
            
            var stud = _student.Search(surname);
            

            if (stud.Count() > 0)
            {
                return View("SearchOutput", stud);
            }
            else
            {
                return RedirectToAction(nameof(Search), new { isSuccess = false });
              
            }

          
        }



    }
}
