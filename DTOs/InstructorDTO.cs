using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class InstructorDTO
    {
        public int ID { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Display(Name = "FirstMidName")] 
        public string FirstMidName { get; set; }
        [Display(Name = "HireDate")] 
        public DateTime HireDate { get; set; }
        [Display(Name = "OfficeAssignment")]
        public OfficeAssignmentDTO OfficeAssignmentDTO { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", LastName, FirstMidName);

            }
        }

    }
}
