using Consultant.Data;
using Consultant.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Company>> GetCompanyAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            return await _context.Companies.SingleOrDefaultAsync(x => x.Id == companyId);
        }

        public async Task<bool> CreateCompanyAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        
        public async Task<bool> UpdateCompanyAsync(Company companyToUpdate)
        {
            _context.Companies.Update(companyToUpdate);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteCompanyAsync(int companyId)
        {
            var company = await GetCompanyByIdAsync(companyId);

            if (company == null)
                return false;

            _context.Companies.Remove(company);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
