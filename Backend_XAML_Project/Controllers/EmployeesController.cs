using Consultant.Contracts;
using Consultant.Contracts.Requests;
using Consultant.Contracts.Responses;
using Consultant.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet(ApiRoutes.Employees.GetAllEmployees)]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employeeService.GetEmployeesAsync());
        }

        [HttpGet(ApiRoutes.Employees.GetEmployee)]
        public async Task<IActionResult> GetEmployee([FromRoute]int employeeId)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut(ApiRoutes.Employees.UpdateEmployee)]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int employeeId, [FromBody] UpdateEmployeeRequest request)
        {
            var employee = new Employee
            {
                Id = employeeId,
                Name = request.Name
            };

            var updated = await _employeeService.UpdateEmployeeAsync(employee);

            if (updated)
                return Ok(employee);

            return NotFound();
        }

        [HttpPost(ApiRoutes.Employees.CreateEmployee)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest employeeRequest)
        {
            var employee = new Employee { Name = employeeRequest.Name };

            await _employeeService.CreateEmployeeAsync(employee);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUri = baseUrl + "/" + ApiRoutes.Employees.GetEmployee.Replace("{employeeId}", employee.Id.ToString());

            var response = new EmployeeResponse { Id = employee.Id };

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Employees.DeleteEmployee)]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int employeeId)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(employeeId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

    }
}
