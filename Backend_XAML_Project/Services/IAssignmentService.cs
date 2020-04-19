using Consultant.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultant
{
    public interface IAssignmentService
    {
        Task <List<Assignment>> GetAssignmentsAsync();

        Task<Assignment> GetAssignmentByIdAsync(int assigmentId);

        Task<bool> CreateAssignmentAsync(Assignment assigment);

        Task<bool> UpdateAssignmentAsync(Assignment assigmentToUpdate);

        Task<bool> DeleteAssignmentAsync(int assigmentId);
    }
}
