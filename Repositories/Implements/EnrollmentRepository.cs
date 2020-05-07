﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContosoUniversity.Repositories.Implements
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private SchoolContext schoolContext;
        public EnrollmentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public new async Task<List<Enrollment>> GetAll()
        {
            var listEnrollments = await schoolContext.Enrollments
                .Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();

            /* var listEnrollments = await (from enrollments in schoolContext.Enrollments
                                  join course in schoolContext.Courses on enrollments.CourseID equals course.CourseID
                                  join student in schoolContext.Students on enrollments.StudentID equals student.ID
                                  select enrollments).ToListAsync(); */


            return listEnrollments;
        }
    }
}
