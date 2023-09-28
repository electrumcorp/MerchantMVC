using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Card
    {
        public Card()
        {
            LoyaltyTransactionTEcs = new HashSet<LoyaltyTransactionTEc>();
        }

        public int CardId { get; set; }
        public int? EntityId { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? ProgramId { get; set; }
        public int? ServiceContractId { get; set; }
        public int? SalesContractId { get; set; }
        public int? CustomerId { get; set; }
        public int? PersonId { get; set; }
        public int? CardBinId { get; set; }
        public int? CardTypeId { get; set; }
        public int? SalesOrgId { get; set; }
        public int? MerchantId { get; set; }
        public int? LocationId { get; set; }
        public string MIdnum { get; set; }
        public string LIdnum { get; set; }
        public string CIdnum { get; set; }
        public string ChPrefix { get; set; }
        public string ChAcct { get; set; }
        public string AcctNum { get; set; }
        public string AccountNumber { get; set; }
        public string CardMag { get; set; }
        public string Pin { get; set; }
        public string Ivrwebpin { get; set; }
        public string ChStatus { get; set; }
        public string ChNotes { get; set; }
        public string ChOtb { get; set; }
        public string ChPadotb { get; set; }
        public string ChSsn { get; set; }
        public string ChCctype { get; set; }
        public string ChCcnum { get; set; }
        public DateTime? ChCcexp { get; set; }
        public int? ExpDate { get; set; }
        public DateTime? ChDob { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? ChEdate { get; set; }
        public string ChSalut { get; set; }
        public string ChFname { get; set; }
        public string ChInitial { get; set; }
        public string ChLname { get; set; }
        public string ChHaddr1 { get; set; }
        public string ChHaddr2 { get; set; }
        public string ChHcity { get; set; }
        public string ChHstate { get; set; }
        public string ChHzip { get; set; }
        public string ChHphone { get; set; }
        public string ChWaddr1 { get; set; }
        public string ChWaddr2 { get; set; }
        public string ChWcity { get; set; }
        public string ChWstate { get; set; }
        public string ChWzip { get; set; }
        public string ChWphone { get; set; }
        public string DlState { get; set; }
        public string DlNum { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string CpCode { get; set; }
        public string IssuerId { get; set; }
        public string SecretWord { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string Income { get; set; }
        public double? Adults { get; set; }
        public DateTime? BillCardDate { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? AchposttDate { get; set; }
        public string Phonefax { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CountryId { get; set; }
        public string Service { get; set; }
        public byte? VelocityHitCount { get; set; }
        public byte? VelocityPeriod { get; set; }
        public string BillPayExternalId { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? FirstTransactionDate { get; set; }
        public int? FirstLoadTransEnterEdid { get; set; }
        public int? AssociatedCardId { get; set; }
        public int? ActivateId { get; set; }
        public int? ActivationCategoryId { get; set; }
        public DateTime? CardIdassignDate { get; set; }
        public int? PrivacyLevel { get; set; }
        public int? ReplacementCard { get; set; }
        public int? CommunicationsDeliveryCategoryId { get; set; }
        public int? CardIssuerId { get; set; }
        public int? PreviousCustomerId { get; set; }
        public int? CardRelationshipCategoryId { get; set; }
        public int? EnrollmentLocationId { get; set; }
        public string ChMphone { get; set; }
        public byte[] AccountBarCode { get; set; }
        public DateTime? PayEnableDate { get; set; }
        public bool? EmailConfirmed { get; set; }
        public int? EmailValidationCategoryId { get; set; }
        public DateTime? LastTransDate { get; set; }
        public int? MobilePhoneValidationCategoryId { get; set; }
        public bool? EmailValidationPointsAwarded { get; set; }
        public bool? MobilePhoneValidationPointsAwarded { get; set; }
        public DateTime? MobileAppLinkDate { get; set; }

        public virtual CardType CardType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Program Program { get; set; }
        public virtual ICollection<LoyaltyTransactionTEc> LoyaltyTransactionTEcs { get; set; }
    }
}
