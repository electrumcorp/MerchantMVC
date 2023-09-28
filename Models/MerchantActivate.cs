using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MerchantMVC.Models
{
    [Table("MerchantActivate")]
    public partial class MerchantActivate
    {
        [Key]
        [Column("MerchantActivateID")]
        public int MerchantActivateId { get; set; }
        [Column("MerchantID")]
        public int? MerchantId { get; set; }
        [Column("EntityID")]
        public int? EntityId { get; set; }
        [Column("EntityCategoryID")]
        public int? EntityCategoryId { get; set; }
        [Column("ProgramID")]
        public int? ProgramId { get; set; }
        [Column("M_NAME")]
        [StringLength(50)]
        public string MName { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [Column("M_EDATE", TypeName = "smalldatetime")]
        public DateTime? MEdate { get; set; }
        [Column("M_SALUT")]
        [StringLength(4)]
        public string MSalut { get; set; }
        [Column("M_FNAME")]
        [StringLength(20)]
        public string MFname { get; set; }
        [Column("M_LNAME")]
        [StringLength(30)]
        public string MLname { get; set; }
        [Column("M_ADDR1")]
        [StringLength(30)]
        public string MAddr1 { get; set; }
        [Column("M_ADDR2")]
        [StringLength(30)]
        public string MAddr2 { get; set; }
        [Column("M_CITY")]
        [StringLength(20)]
        public string MCity { get; set; }
        [Column("M_STATE")]
        [StringLength(2)]
        public string MState { get; set; }
        [Column("M_ZIP")]
        [StringLength(10)]
        public string MZip { get; set; }
        public int? CountryiD { get; set; }
        [Column("M_PHONE")]
        [StringLength(15)]
        public string MPhone { get; set; }
        [StringLength(15)]
        public string FaxNumber { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("URLAddress")]
        [StringLength(50)]
        public string Urladdress { get; set; }
        [Column("FedTaxID")]
        [StringLength(20)]
        public string FedTaxId { get; set; }
        [Column("ACH_ID")]
        [StringLength(15)]
        public string AchId { get; set; }
        [Column("M_BATYPE")]
        [StringLength(1)]
        public string MBatype { get; set; }
        [Column("PBANKNAME")]
        [StringLength(50)]
        public string Pbankname { get; set; }
        [Column("PBankCity")]
        [StringLength(50)]
        public string PbankCity { get; set; }
        [Column("M_PABA")]
        [StringLength(9)]
        public string MPaba { get; set; }
        [Column("M_PBNKACCT")]
        [StringLength(17)]
        public string MPbnkacct { get; set; }
        [Column("M_PBATYPE")]
        [StringLength(1)]
        public string MPbatype { get; set; }
        [Column("RBANKNAME")]
        [StringLength(50)]
        public string Rbankname { get; set; }
        [Column("RBankCity")]
        [StringLength(50)]
        public string RbankCity { get; set; }
        [Column("R_ABA")]
        [StringLength(9)]
        public string RAba { get; set; }
        [Column("R_ACCT")]
        [StringLength(17)]
        public string RAcct { get; set; }
        [Column("R_BATYPE")]
        [StringLength(1)]
        public string RBatype { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [StringLength(35)]
        public string PayableTo { get; set; }
        [Column("ServiceContractID")]
        public int? ServiceContractId { get; set; }
        [StringLength(5)]
        public string AcceptAgreement { get; set; }
        [StringLength(50)]
        public string AppCompletedByName { get; set; }
        [StringLength(50)]
        public string AppCompletedByTitle { get; set; }
        [StringLength(50)]
        public string AppCompletedByCo { get; set; }
        [StringLength(15)]
        public string AppCompletedByPhone { get; set; }
        [StringLength(50)]
        public string AppCompletedbyEmail { get; set; }
        public int? Approved { get; set; }
        public int? Imported { get; set; }
        [Column("SalesOrgID")]
        public int? SalesOrgId { get; set; }
        public int? CardsOrdered { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateEmailSent { get; set; }
        public int? MerchantApproved { get; set; }
        [Column("ContractID")]
        public int? ContractId { get; set; }
        [Column("SponsorID")]
        public int? SponsorId { get; set; }
        [Column("SponsorActivateID")]
        public int? SponsorActivateId { get; set; }
        [Column("ProgramActivateID")]
        public int? ProgramActivateId { get; set; }
        [Column("LoyaltyProgramActiivateID")]
        public int? LoyaltyProgramActiivateId { get; set; }
        [Column("ID")]
        public int? Id { get; set; }
        [Column("SourceEntityCategoryID")]
        public int? SourceEntityCategoryId { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column("Hold_Til")]
        public int? HoldTil { get; set; }
        [Column("M_DISCOUNT")]
        public double? MDiscount { get; set; }
        [Column("M_SETUP", TypeName = "money")]
        public decimal? MSetup { get; set; }
        [Column("M_VOL", TypeName = "money")]
        public decimal? MVol { get; set; }
        [Column("M_LIMIT", TypeName = "money")]
        public decimal? MLimit { get; set; }
        public string Fees { get; set; }
        public string Notes { get; set; }
        public int? CreatedBy { get; set; }
        [Column("CreatedByEntityCategoryID")]
        public int? CreatedByEntityCategoryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [Column("UpdatedByEntityCategoryID")]
        public int? UpdatedByEntityCategoryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
