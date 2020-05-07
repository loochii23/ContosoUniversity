using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.DTOs
{
    public class OfficeAssignmentDTO
    {
        public int InstructorID { get; set; }
        [Display(Name = "Location")] 
        public string Location { get; set; }
        [Display(Name = "Instructor")]
        public InstructorDTO InstructorDTO { get; set; }

    }
}
