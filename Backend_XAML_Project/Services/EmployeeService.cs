using Consultant.Data;
using Consultant.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees.SingleOrDefaultAsync(x => x.Id == employeeId);
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        
        public async Task<bool> UpdateEmployeeAsync(Employee employeeToUpdate)
        {
            _context.Employees.Update(employeeToUpdate);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await GetEmployeeByIdAsync(employeeId);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
