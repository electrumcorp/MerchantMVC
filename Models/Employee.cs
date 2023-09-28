using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int? CompanyId { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? Id { get; set; }
        public string DepartmentName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public string NationalEmplNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string EmailName { get; set; }
        public string Extension { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? DateHired { get; set; }
        public decimal? Salary { get; set; }
        public decimal? BillingRate { get; set; }
        public short? Deductions { get; set; }
        public int? SupervisorId { get; set; }
        public string SpouseName { get; set; }
        public string EmrgcyContactName { get; set; }
        public string EmrgcyContactPhone { get; set; }
        public byte[] Photograph { get; set; }
        public string Notes { get; set; }
        public string OfficeLocation { get; set; }
        public string EmployeeEmail { get; set; }
        public string NtloginId { get; set; }
        public int? ActiveIndicatorId { get; set; }
        public int? CategoryId { get; set; }
        public string ResourceInitial { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? ActivateSponsorId { get; set; }
        public int? PrimaryPositionId { get; set; }
        public int? CreatedBy { get; set; }
        public int? CreatedByEntityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UpdatedByEntityId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
