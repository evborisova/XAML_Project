using Consultant.Data;
using Consultant.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly ApplicationDbContext _context;
        
        public AssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int assignmentId)
        {
            return await _context.Assignments.SingleOrDefaultAsync(x => x.Id == assignmentId);
        }

        public async Task<bool> CreateAssignmentAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        
        public async Task<bool> UpdateAssignmentAsync(Assignment assignmentToUpdate)
        {
            _context.Assignments.Update(assignmentToUpdate);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAssignmentAsync(int assignmentId)
        {
            var assignment = await GetAssignmentByIdAsync(assignmentId);

            if (assignment == null)
                return false;

            _context.Assignments.Remove(assignment);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
