using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Domain
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public int WorkingHoursPercentage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}


/*

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("PriceType")]
        public int? PriceTypeId { get; set; }
        public SystemMeta PriceType { get; set; }

        [ForeignKey("PriceCurrency")]
        public int? PriceCurrencyId { get; set; }
        public PriceCurrency PriceCurrency { get; set; }

        [ForeignKey("CompetenceLevel")]
        public int? CompetenceLevelId { get; set; }
        public Category CompetenceLevel { get; set; }
        [ForeignKey("AssignmentType")]
        public int? AssignmentTypeId { get; set; }
        public SystemMeta AssignmentType { get; set; }

        [ForeignKey("RequestType")]
        public int? RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public string Summery { get; set; }
        public float Total { get; set; }
        public DateTime? StartDate { get; set; }
        [ForeignKey("StartDateType")]
        public int? StartDateTypeId { get; set; }
        public SystemMeta StartDateType { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public float? Percent { get; set; }
        public bool Deleted { get; set; }
        //############################################### Extra atributes
        public ICollection<AssignmentKeyword> UserAssignmentKeywords { get; set; }
        public ICollection<UserSavedAssignments> UserSavedAssignments { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<AssignmentItem> AssignmentItem { get; set; }
        public ICollection<AssignmentRequestCompanies> AssignmentRequestCompanies { get; set; }
        public ICollection<AssignmentCompetenceArea> AssignmentCompetenceAreas { get; set; }
 * */
