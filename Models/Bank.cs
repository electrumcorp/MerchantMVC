using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Programs = new HashSet<Program>();
        }

        public int BankId { get; set; }
        public string Bank1 { get; set; }
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
        public string Notes { get; set; }
        public string CommunicationsHelp { get; set; }
        public string FileHelp { get; set; }
        public string CommunicationsPhone { get; set; }
        public string Ftpaddress { get; set; }
        public string SalesContact { get; set; }
        public string SalesPhone { get; set; }
        public string ImmediateDestination { get; set; }
        public string ImmediateOrigin { get; set; }
        public string FileIdModifier { get; set; }
        public string ImmediateDestinationName { get; set; }
        public string ImmediateOriginName { get; set; }
        public string OriginatingDfiidentification { get; set; }
        public int? CompanyId { get; set; }
        public string InstitutionNumber { get; set; }
        public string Url { get; set; }
        public int? ReserveTerminalId { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? AchfileCategoryId { get; set; }
        public string CleariingAba { get; set; }
        public string ClearingAccount { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
