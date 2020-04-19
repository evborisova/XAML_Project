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
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet(ApiRoutes.Companies.GetAllCompanies)]
        public async Task<IActionResult> GetAllCompanies()
        {
            return Ok(await _companyService.GetCompanyAsync());
        }

        [HttpGet(ApiRoutes.Companies.GetCompany)]
        public async Task<IActionResult> GetCompany([FromRoute]int companyId)
        {
            var company = await _companyService.GetCompanyByIdAsync(companyId);

            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpPut(ApiRoutes.Companies.UpdateCompany)]
        public async Task<IActionResult> UpdateCompany([FromRoute]int companyId, [FromBody] UpdateCompanyRequest request)
        {
            var company = new Company
            {
                Id = companyId,
                Name = request.Name
            };

            var updated = await _companyService.UpdateCompanyAsync(company);

            if (updated)
                return Ok(company);

            return NotFound();
        }

        [HttpPost(ApiRoutes.Companies.CreateCompany)]
        public async Task<IActionResult> Create([FromBody] CreateCompanyRequest companyRequest)
        {
            var company = new Company { Name = companyRequest.Name };

            await _companyService.CreateCompanyAsync(company);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUri = baseUrl + "/" + ApiRoutes.Companies.GetCompany.Replace("{companyId}", company.Id.ToString());

            var response = new CompanyResponse { Id = company.Id };

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Companies.DeleteCompany)]
        public async Task<IActionResult> DeleteCompany([FromRoute] int companyId)
        {
            var deleted = await _companyService.DeleteCompanyAsync(companyId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

    }
}
