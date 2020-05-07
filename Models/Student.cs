﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID{ get; set; }
        public string LastName { get; set; }
        public string FirstMidName{ get; set; }
        public DateTime EnrollmentDate { get; set; }


        public ICollection<Enrollment> Enrollment { get; set; }


        public string FullName {
            get {
                return string.Format("{0} {1}", LastName, FirstMidName);
            }
        }
    }
}
