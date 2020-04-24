using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private SchoolContext schoolContext;
        public CourseRepository(SchoolContext dbContext) : base(dbContext) {
            this.schoolContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetStudentsByCourse(int id)
        {
            //var listStudents = schoolContext.Enrollments
            //    .Include(x => x.Student)
            //    .Where(x => x.CourseID == id)
            //    .Select(x => x.Student)
            //    .ToListAsync();

            var listStudents = await (from enrrollment in schoolContext.Enrollments
                                join student in schoolContext.Students on enrrollment.StudentID equals student.ID
                                where enrrollment.CourseID == id
                                select student).ToListAsync();
            return listStudents;
        }

        public new async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            var hasRelations = schoolContext.Enrollments.Any(x => x.Course.CourseID == id);

            if (hasRelations)
                throw new Exception("The course has enrollments");

            schoolContext.Courses.Remove(entity);
            await schoolContext.SaveChangesAsync();
        }
    }
}