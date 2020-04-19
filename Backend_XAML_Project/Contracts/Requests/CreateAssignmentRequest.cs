using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Contracts.Requests
{
    public class CreateAssignmentRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public int WorkingHoursPercentage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
