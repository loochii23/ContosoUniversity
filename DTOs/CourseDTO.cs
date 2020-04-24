using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class CourseDTO
    {
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Credits are required")]
        [Display(Name = "Credits")]
        public int Credits { get; set; }
    }
}
