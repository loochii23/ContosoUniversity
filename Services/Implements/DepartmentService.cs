using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class DepartmentService : GenericService<Department>, IDepartmentService
    {
        private IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            this.departmentRepository = departmentRepository;

        }
    }
}
