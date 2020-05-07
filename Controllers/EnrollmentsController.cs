using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Services;
using ContosoUniversity.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoUniversity.Controllers
{
    public class EnrollmentsController : Controller
    {
        private IEnrollmentService enrollmentService;
        private IStudentService studentService;
        private ICourseService courseService;
        public EnrollmentsController(IEnrollmentService enrollmentService,
            IStudentService studentService,
            ICourseService courseService)
        {
            this.enrollmentService = enrollmentService;
            this.studentService = studentService;
            this.courseService = courseService;

        }
        
        public async Task<IActionResult> Index()
        {
            var listEnrollments = await enrollmentService.GetAll();
            return View(listEnrollments);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Courses = await courseService.GetAll();
            ViewBag.Students = await studentService.GetAll();

            //List<String> grades = new List<String> { "A", "B", "C", "D", "F" };
            //ViewBag.Grades = grades;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Enrollment model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return RedirectToAction("Index");
        }
    }
}
