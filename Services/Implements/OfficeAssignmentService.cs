using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class OfficeAssignmentService : GenericService<OfficeAssignment>, IOfficeAssignmentService
    {
        private IOfficeAssignmentRepository OfficeAssignmentRepository;

        public OfficeAssignmentService(IOfficeAssignmentRepository OfficeAssignmentRepository) : base(OfficeAssignmentRepository)
        {
            this.OfficeAssignmentRepository = OfficeAssignmentRepository;

        }
    }
}
