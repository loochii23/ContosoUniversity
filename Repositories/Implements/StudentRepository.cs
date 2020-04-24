using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private SchoolContext schoolContext;
        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudent(int id)
        {

            var listCourses = await (from enrrollment in schoolContext.Enrollments
                                      join course in schoolContext.Courses on enrrollment.CourseID equals course.CourseID
                                      where enrrollment.StudentID == id
                                      select course).ToListAsync();
            return listCourses;
        }
    }
}