using AutoMapper;
using ContosoUniversity.Models;

namespace ContosoUniversity.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<InstructorDTO, Instructor>();
            CreateMap<Instructor, InstructorDTO>()
                .ForMember(dest =>
                dest.OfficeAssignmentDTO,
                opt => opt.MapFrom(src => src.OfficeAssignment));
            CreateMap<OfficeAssignmentDTO, OfficeAssignment>();
            CreateMap<OfficeAssignment, OfficeAssignmentDTO>();
            CreateMap<EnrollmentDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentDTO>();
        }
    }
}