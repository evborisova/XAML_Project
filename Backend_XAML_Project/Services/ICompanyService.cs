using Consultant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant
{
    public interface ICompanyService
    {
        Task <List<Company>> GetCompanyAsync();

        Task<Company> GetCompanyByIdAsync(int companyId);

        Task<bool> CreateCompanyAsync(Company company);

        Task<bool> UpdateCompanyAsync(Company companyToUpdate);

        Task<bool> DeleteCompanyAsync(int companyId);
    }
}
