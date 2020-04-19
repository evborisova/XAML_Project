using Consultant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant
{
    public interface IEmployeeService
    {
        Task <List<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int employeeId);

        Task<bool> CreateEmployeeAsync(Employee employee);

        Task<bool> UpdateEmployeeAsync(Employee employeeToUpdate);

        Task<bool> DeleteEmployeeAsync(int employeeId);
    }
}
