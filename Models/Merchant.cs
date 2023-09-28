using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MerchantMVC.Models
{
    [Table("Merchant")]
    public partial class Merchant
    {
        [Key]
        [Column("MerchantID")]
        public int MerchantId { get; set; }
        [Column("EntityID")]
        public int? EntityId { get; set; }
        [Column("EntityCategoryID")]
        public int? EntityCategoryId { get; set; }
        [Column("PersonID")]
        public int? PersonId { get; set; }
        [Column("ProgramID")]
        public int? ProgramId { get; set; }
        [Column("SalesRepID")]
        public int? SalesRepId { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }
        [Column("M_IDNUM")]
        [StringLength(6)]
        public string MIdnum { get; set; }
        [StringLength(16)]
        public string AccountNumber { get; set; }
        [Column("CardID")]
        public int? CardId { get; set; }
        [Column("M_NAME")]
        [StringLength(50)]
        public string MName { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [Column("M_STATUS")]
        [StringLength(1)]
        public string MStatus { get; set; }
        [Column("M_EDATE", TypeName = "smalldatetime")]
        public DateTime? MEdate { get; set; }
        [Column("M_SALUT")]
        [StringLength(4)]
        public string MSalut { get; set; }
        [Column("M_FNAME")]
        [StringLength(20)]
        public string MFname { get; set; }
        [Column("M_INITIAL")]
        [StringLength(1)]
        public string MInitial { get; set; }
        [Column("M_LNAME")]
        [StringLength(20)]
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
        [Column("M_EXTEN")]
        [StringLength(4)]
        public string MExten { get; set; }
        [StringLength(15)]
        public string FaxNumber { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("contactphone")]
        [StringLength(15)]
        public string Contactphone { get; set; }
        [Column("URLAddress")]
        [StringLength(50)]
        public string Urladdress { get; set; }
        [Column("M_PASS")]
        [StringLength(15)]
        public string MPass { get; set; }
        [Column("M_DISCOUNT")]
        public double? MDiscount { get; set; }
        [Column("M_SETUP")]
        public double? MSetup { get; set; }
        [Column("M_VOL")]
        public double? MVol { get; set; }
        [Column("M_LIMIT")]
        public double? MLimit { get; set; }
        [Column("M_ABA")]
        [StringLength(9)]
        public string MAba { get; set; }
        [Column("M_BNKACCT")]
        [StringLength(17)]
        public string MBnkacct { get; set; }
        [Column("CBANKNAME")]
        [StringLength(50)]
        public string Cbankname { get; set; }
        [Column("M_BATYPE")]
        [StringLength(1)]
        public string MBatype { get; set; }
        [Column("PBANKNAME")]
        [StringLength(50)]
        public string Pbankname { get; set; }
        [Column("PBankAddress")]
        [StringLength(50)]
        public string PbankAddress { get; set; }
        [StringLength(2)]
        public string PbankState { get; set; }
        [Column("PBankZip")]
        [StringLength(10)]
        public string PbankZip { get; set; }
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
        [Column("PBankCity")]
        [StringLength(50)]
        public string PbankCity { get; set; }
        [Column("R_ABA")]
        [StringLength(9)]
        public string RAba { get; set; }
        [Column("R_ACCT")]
        [StringLength(17)]
        public string RAcct { get; set; }
        [Column("R_BATYPE")]
        [StringLength(1)]
        public string RBatype { get; set; }
        [Column("RCK")]
        [StringLength(50)]
        public string Rck { get; set; }
        [Column("CheckCollectMerchantID")]
        public int? CheckCollectMerchantId { get; set; }
        [Column("H_DAYS")]
        public double? HDays { get; set; }
        [Column("R_DAYS")]
        public double? RDays { get; set; }
        [Column("M_TPERD")]
        public double? MTperd { get; set; }
        [Column("M_DPERD")]
        public double? MDperd { get; set; }
        [Column("M_DPERT")]
        public double? MDpert { get; set; }
        [Column("ACH_ID")]
        [StringLength(11)]
        public string AchId { get; set; }
        [Column("TAX_ID")]
        [StringLength(11)]
        public string TaxId { get; set; }
        [Column("EmployeeID")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [Column("RESERVED1")]
        [StringLength(25)]
        public string Reserved1 { get; set; }
        [Column("RESERVED2")]
        [StringLength(25)]
        public string Reserved2 { get; set; }
        [Column("RESERVED3")]
        [StringLength(50)]
        public string Reserved3 { get; set; }
        [Column("RESERVED4")]
        [StringLength(25)]
        public string Reserved4 { get; set; }
        [Column("RESERVED5")]
        [StringLength(25)]
        public string Reserved5 { get; set; }
        [Column("FIELDNAME1")]
        [StringLength(20)]
        public string Fieldname1 { get; set; }
        [Column("FIELDNAME2")]
        [StringLength(20)]
        public string Fieldname2 { get; set; }
        [Column("FIELDNAME3")]
        [StringLength(20)]
        public string Fieldname3 { get; set; }
        [Column("FIELDNAME4")]
        [StringLength(20)]
        public string Fieldname4 { get; set; }
        [Column("FIELDNAME5")]
        [StringLength(20)]
        public string Fieldname5 { get; set; }
        [Column("CIC")]
        [StringLength(30)]
        public string Cic { get; set; }
        public int? BillCard { get; set; }
        public int? BillCardAmt { get; set; }
        [Column("ODFIID")]
        public int? Odfiid { get; set; }
        public int? DeclineCheck { get; set; }
        public int? Collect { get; set; }
        [StringLength(15)]
        public string UserName { get; set; }
        [StringLength(15)]
        public string Password { get; set; }
        public string Comments { get; set; }
        [StringLength(10)]
        public string AcctStat { get; set; }
        [StringLength(15)]
        public string Logo { get; set; }
        [StringLength(35)]
        public string PayableTo { get; set; }
        [Column("OTB1Period")]
        public int? Otb1period { get; set; }
        [Column("OTB2Period")]
        public int? Otb2period { get; set; }
        [Column("OTB3Period")]
        public int? Otb3period { get; set; }
        [Column("OTB4Period")]
        public int? Otb4period { get; set; }
        [Column("OTB5Period")]
        public int? Otb5period { get; set; }
        [Column("hold_til")]
        public double? HoldTil { get; set; }
        [Column("ReserveOTB", TypeName = "money")]
        public decimal? ReserveOtb { get; set; }
        [Column("ServiceContractID")]
        public int? ServiceContractId { get; set; }
        [Column("MerchantActivateID")]
        public int? MerchantActivateId { get; set; }
        public int? PrivacyLevel { get; set; }
        [Column("CheckCollectTerminalID")]
        public int? CheckCollectTerminalId { get; set; }
        public int? GroupSettlement { get; set; }
        public int? GroupRejects { get; set; }
        [Column("CBTerminalID")]
        public int? CbterminalId { get; set; }
        [StringLength(50)]
        public string StoreManagementSystem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CloseTime { get; set; }
        [Column("TimeZoneID")]
        public int? TimeZoneId { get; set; }
        [Column("MerchantEmployeeID")]
        public int? MerchantEmployeeId { get; set; }
        [Column("MaxSKUDescriptorLength")]
        public int? MaxSkudescriptorLength { get; set; }
        public int? CreatedBy { get; set; }
        [Column("CreatedByEntityID")]
        public int? CreatedByEntityId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [Column("UpdatedByEntityID")]
        public int? UpdatedByEntityId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("SKUMatchingCategoryID")]
        public int? SkumatchingCategoryId { get; set; }
        [Column("PriceBookUPCsHaveLeadingZeros")]
        public int? PriceBookUpcsHaveLeadingZeros { get; set; }
        [Column("PriceBookUPCsHaveCheckDigit")]
        public int? PriceBookUpcsHaveCheckDigit { get; set; }
        [Column("AltIDPriorityCategoryID")]
        public int? AltIdpriorityCategoryId { get; set; }

        public List<Location> Locations { get; set; }
    }
}
