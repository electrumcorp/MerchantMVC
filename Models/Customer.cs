using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cards = new HashSet<Card>();
        }

        public int CustomerId { get; set; }
        public int? EntityId { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? SalesRepId { get; set; }
        public int? MerchantId { get; set; }
        public int? PersonId { get; set; }
        public int? ClientId { get; set; }
        public int? RemittanceId { get; set; }
        public int? ProgramId { get; set; }
        public string AccountNumber { get; set; }
        public string MIdnum { get; set; }
        public string LIdnum { get; set; }
        public string CIdnum { get; set; }
        public string PreferredBankName { get; set; }
        public string CAchid { get; set; }
        public string CAba { get; set; }
        public string CBnkacct { get; set; }
        public string CBatype { get; set; }
        public string CardName { get; set; }
        public string CName { get; set; }
        public string CSalut { get; set; }
        public string CFname { get; set; }
        public string CInitial { get; set; }
        public string CLname { get; set; }
        public string CAddr1 { get; set; }
        public string CAddr2 { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CZip { get; set; }
        public int? CountryId { get; set; }
        public string CPhone { get; set; }
        public string CExt { get; set; }
        public string Email { get; set; }
        public string PhoneFax { get; set; }
        public string CTerms { get; set; }
        public string OpId { get; set; }
        public DateTime? EntryDate { get; set; }
        public double? Balance { get; set; }
        public double? BalCur { get; set; }
        public double? Bal30 { get; set; }
        public double? Bal45 { get; set; }
        public double? Bal60 { get; set; }
        public double? Bal90 { get; set; }
        public double? Bal120 { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public int? CategoryId { get; set; }
        public int? EmsLiable { get; set; }
        public string Status { get; set; }
        public DateTime? SentColl { get; set; }
        public double? CollBal { get; set; }
        public string ClaimNum { get; set; }
        public string Fieldname1 { get; set; }
        public string Fieldname2 { get; set; }
        public string Fieldname3 { get; set; }
        public string Fieldname4 { get; set; }
        public string Fieldname5 { get; set; }
        public string CBusaddr1 { get; set; }
        public string CBusaddr2 { get; set; }
        public string CBuscity { get; set; }
        public string CBusstate { get; set; }
        public string CBuszip { get; set; }
        public double? NumCards { get; set; }
        public string Fieldnamecard1 { get; set; }
        public string Fieldnamecard2 { get; set; }
        public string Fieldnamecard3 { get; set; }
        public string Fieldnamecard4 { get; set; }
        public string Fieldnamecard5 { get; set; }
        public DateTime? Adddate { get; set; }
        public string BeginningCardNumber { get; set; }
        public string EndingCardNumber { get; set; }
        public DateTime? DateMailed { get; set; }
        public string CNotes { get; set; }
        public int? Otb1period { get; set; }
        public int? Otb2period { get; set; }
        public int? Otb3period { get; set; }
        public int? Otb4period { get; set; }
        public int? Otb5period { get; set; }
        public int? PrintLabel { get; set; }
        public string BusinessForm { get; set; }
        public string CustomerServiceNo { get; set; }
        public string CustomerServiceContact { get; set; }
        public string IssuerCode { get; set; }
        public int? ActivateId { get; set; }
        public int? PrivacyLevel { get; set; }
        public int? SettlementCategoryId { get; set; }
        public int? PeriodCategoryId { get; set; }
        public string FedTaxId { get; set; }
        public int? CommunicationsDeliveryCategoryId { get; set; }
        public decimal? CreditLimit { get; set; }
        public int? ServiceContractId { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
