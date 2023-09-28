using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Program
    {
        public Program()
        {
            Cards = new HashSet<Card>();
        }

        public int ProgramId { get; set; }
        public int? CompanyId { get; set; }
        public int? ServiceId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramProcessorId { get; set; }
        public int? SponsorId { get; set; }
        public int? BankId { get; set; }
        public int? ProcessorId { get; set; }
        public string UserDefineLabel1 { get; set; }
        public string UserDefineLabel2 { get; set; }
        public string UserDefineLabel3 { get; set; }
        public string UserDefineLabel4 { get; set; }
        public string UserDefineLabel5 { get; set; }
        public int? EntityId { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? ParentProgramId { get; set; }
        public string Bin { get; set; }
        public int? TapagingLimit { get; set; }
        public decimal? CardToCardMin { get; set; }
        public decimal? CardToCardMax { get; set; }
        public int? TerminalId { get; set; }
        public int? CardId { get; set; }
        public string LotSize { get; set; }
        public int? Status { get; set; }
        public int? ClientCategoryId { get; set; }
        public int? GroupTransactions { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public int? MerchantId { get; set; }
        public int? HoldDate { get; set; }
        public int? HoldTil { get; set; }
        public int? AuthExpiration { get; set; }
        public decimal? InitialCreditLimit { get; set; }
        public decimal? TransactionMaximum { get; set; }
        public decimal? TransactionMinimum { get; set; }
        public decimal? Otbmax { get; set; }
        public decimal? Otbmin { get; set; }
        public int? OtbmanagementEnable { get; set; }
        public int? IssuanceCategoryId { get; set; }
        public int? CardIssueUpon { get; set; }
        public string CascadingStyleSheet { get; set; }
        public string InstitutionNumber { get; set; }
        public decimal? ReOrderLevel { get; set; }
        public int? ActivityAccountTerminalId { get; set; }
        public int? FundingAccountCardId { get; set; }
        public int? EnrollmentCategoryId { get; set; }
        public int? PostToClearing { get; set; }
        public int? Arfid { get; set; }
        public int? MerchantCheck { get; set; }
        public int? ReserveTerminalId { get; set; }
        public int? CollectionTerminalId { get; set; }
        public string StatementName { get; set; }
        public int? ProgramCategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? SalesOrgId { get; set; }
        public decimal? Otbinitial { get; set; }
        public bool? Prenote { get; set; }
        public string OperatorPhone { get; set; }
        public int? ChoicePointEnrollValidate { get; set; }
        public int? NcnenrollValidate { get; set; }
        public int? DuplicateCheck { get; set; }
        public string ProcessorSystemNumber { get; set; }
        public string ProcessorPrincipalBankNumber { get; set; }
        public string ShrinkageFactor { get; set; }
        public int? AchcategoryId { get; set; }
        public int? EnrollmentMonitorPeriod { get; set; }
        public int? TxnMonitorPeriod { get; set; }
        public string DeclineHeader1 { get; set; }
        public string DeclineHeader2 { get; set; }
        public string DeclineFooter1 { get; set; }
        public string DeclineFooter2 { get; set; }
        public string DeclinePreHeader1 { get; set; }
        public string DeclinePreHeader2 { get; set; }
        public string DeclinePreFooter1 { get; set; }
        public string DeclinePreFooter2 { get; set; }
        public string DeclineAdminHeader1 { get; set; }
        public string DeclineAdminHeader2 { get; set; }
        public string DeclineAdminFooter1 { get; set; }
        public string DeclineAdminFooter2 { get; set; }
        public int? AdminRepairDaysMax { get; set; }
        public int? LostAndStolenLocationId { get; set; }
        public string HelpDeskPhoneNumber { get; set; }
        public int? HelpdeskId { get; set; }
        public byte[] Timestamp { get; set; }
        public byte[] Logo { get; set; }
        public int? PwdCategoryId { get; set; }
        public int? SystemId { get; set; }
        public int? CreditOffSetTerminalId { get; set; }
        public int? ProgramActivateId { get; set; }
        public int? OtbpreAuthMaximum { get; set; }
        public int? BarCodeCategoryId { get; set; }
        public bool? AllowCardServiceChange { get; set; }
        public int? CardActivationCategoryId { get; set; }
        public string ProgramInstitutionNumber { get; set; }
        public int? MobileSupplierId { get; set; }
        public int? QstatusAuthBehaviorCategoryId { get; set; }
        public int? AstatusAuthBehaviorCategoryId { get; set; }
        public int? TermsConditionsDocId { get; set; }
        public int? PrivacyPolicyDocumentsId { get; set; }
        public string FontLink { get; set; }
        public int? BackOfficeSupplierId { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Company Company { get; set; }
        public virtual Processor Processor { get; set; }
        public virtual Service Service { get; set; }
        public virtual Sponsor Sponsor { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
