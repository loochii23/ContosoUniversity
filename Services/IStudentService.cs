using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoUniversity.Models;

namespace ContosoUniversity.Services
{
    public interface IStudentService : IGenericService<Student>
    {
        Task<IEnumerable<Course>> GetCoursesByStudent(int id);
    }
}