using Application.Dtos;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmployeeRepository : EfEntityRepository<Employee, EmployeeContext, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeeByLastName(string lastname)
        {
            return await _context.Employees.AsNoTracking().Select(Emp => new EmployeeDTO
            {
                Id = Emp.Id,
                FirstName = Emp.FirstName,
                LastName = Emp.LastName,
                PhoneNumber = Emp.PhoneNumber,
                DateOfBirth = Emp.DateOfBirth,
                Email = Emp.Email
            }).ToListAsync();
        }
    }
}
