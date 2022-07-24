using Application.Interfaces.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeContext _context;

        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
