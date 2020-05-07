﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class EnrollmentService : GenericService<Enrollment>, IEnrollmentService
    {
        private IEnrollmentRepository enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository) : base(enrollmentRepository)
        {
        }
    }
}
