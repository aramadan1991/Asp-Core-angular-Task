using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee,Guid>
    {
         Task<IEnumerable<EmployeeDTO>> GetEmployeeByLastName(string lastname);

    }
}
