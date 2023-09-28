using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Company
    {
        public Company()
        {
            Programs = new HashSet<Program>();
        }

        public int CompanyId { get; set; }
        public int? EntityCategoryId { get; set; }
        public string CompanyName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string CompanyOrDepartment { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string ContactTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FedTaxId { get; set; }
        public string Notes { get; set; }
        public string MIdnum { get; set; }
        public int? MerchantId { get; set; }
        public int? TerminalId { get; set; }
        public string CascadingStyleSheet { get; set; }
        public int? Sponsorid { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
