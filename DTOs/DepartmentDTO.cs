using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Budget")]
        public decimal Budget { get; set; }
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Instructor")]
        public int InstructorID { get; set; }
    }
}
