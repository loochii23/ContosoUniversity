using ContosoUniversity.Models;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ContosoUniversity.DTOs;
using AutoMapper;
using System.Linq;

namespace ContosoUniversity.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper mapper;

        public StudentController(IStudentService studentService,
            IMapper mapper)
        {
            _studentService = studentService;
            this.mapper = mapper;
        }

        // GET: Students
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                var dataCourses = await _studentService.GetCoursesByStudent(id.Value);
                ViewBag.Courses = dataCourses.Select(x => mapper.Map<CourseDTO>(x)).ToList();
            }
            var data = await _studentService.GetAll();
            var listStudents = data.Select(x => mapper.Map<StudentDTO>(x)).ToList();
            return View(listStudents);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetById(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = mapper.Map<StudentDTO>(student);

            return View(studentDTO);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentDTO studentDTO)
        {
            if (ModelState.IsValid)
            {
                var student = mapper.Map<Student>(studentDTO);
                student.EnrollmentDate = Convert.ToDateTime(student.EnrollmentDate.ToString("yyyy-MM-dd"));
                await _studentService.Insert(student);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDTO);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetById(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = mapper.Map<StudentDTO>(student);
            return View(studentDTO);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentDTO studentDTO)
        {
            if (id != studentDTO.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var student = mapper.Map<Student>(studentDTO);
                await _studentService.Update(student);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDTO);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetById(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = mapper.Map<StudentDTO>(student);

            return View(studentDTO);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
