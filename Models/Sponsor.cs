using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Sponsor
    {
        public Sponsor()
        {
            Programs = new HashSet<Program>();
        }

        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public int? EntityId { get; set; }
        public int? ClientId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string FedTaxId { get; set; }
        public DateTime? ContractBeginDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public DateTime? ContractNotifyDate { get; set; }
        public string CascadingStyleSheet { get; set; }
        public string SystemNumber { get; set; }
        public string PrincipalBankNumber { get; set; }
        public string SponsorAchext { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? CardId { get; set; }
        public string PapclientNumber { get; set; }
        public string PdsclientNumber { get; set; }
        public string FieldName1 { get; set; }
        public string FieldName2 { get; set; }
        public int? LostStolenLocationId { get; set; }
        public int? MerchantId { get; set; }
        public int? SystemId { get; set; }
        public string StandardEntryClassCode { get; set; }
        public int? DefaultLoyaltyVendorId { get; set; }
        public int? SponsorActivateId { get; set; }
        public int? ServiceContractId { get; set; }
        public int? MaxSkudescriptorLength { get; set; }
        public int? MobileApplicationId { get; set; }
        public int? CreatedBy { get; set; }
        public int? CreatedByEntityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UpdatedByEntityId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? SponsorEmployeeId { get; set; }
        public int? LoyaltyvendorId { get; set; }
        public int? PermissionId { get; set; }
        public int? SkumatchingCategoryId { get; set; }
        public bool? PriceBookUpcsHaveLeadingZeros { get; set; }
        public bool? PriceBookUpcsHaveCheckDigit { get; set; }
        public int? AltIdpriorityCategoryId { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
