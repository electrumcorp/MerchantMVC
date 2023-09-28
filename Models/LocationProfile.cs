using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MerchantMVC.Models
{
    [Table("LocationProfile_T_EC")]
    public partial class LocationProfile
    {
        [Key]
        [Column("LocationProfileID")]
        public int LocationProfileId { get; set; }
        [Column("LocationID")]
        public int? LocationId { get; set; }
        [Column("SICCode")]
        public int? Siccode { get; set; }
        public int? NumberTerminals { get; set; }
        [Column("Merchant_Number")]
        [StringLength(12)]
        public string MerchantNumber { get; set; }
        [StringLength(50)]
        public string PumpDispenserModel { get; set; }
        [StringLength(50)]
        public string InternetServiceProvider { get; set; }
        [MaxLength(50)]
        public byte[] WifiSecurityType { get; set; }
        [StringLength(50)]
        public string WifiKey { get; set; }
        [StringLength(20)]
        public string FuelBrand { get; set; }
        [StringLength(50)]
        public string StoreManagementSystem { get; set; }
        [Column("POSControlerOrginationDevID")]
        public int? PoscontrolerOrginationDevId { get; set; }
        [Column("POSTerminalOrigDevID")]
        public int? PosterminalOrigDevId { get; set; }
        [Column("POSSystem")]
        [StringLength(50)]
        public string Possystem { get; set; }
        [Column("POSAppplication")]
        [StringLength(50)]
        public string Posappplication { get; set; }
        [Column("POSApplicationVersion")]
        [StringLength(50)]
        public string PosapplicationVersion { get; set; }
        [StringLength(10)]
        public string RackBarrelHeight { get; set; }
        [StringLength(10)]
        public string PumpTopperSize { get; set; }
        [StringLength(50)]
        public string SurgeProtection { get; set; }
        [StringLength(50)]
        public string CreditCardAcquirer { get; set; }
        [StringLength(100)]
        public string CardsAccpeted { get; set; }
        public string CreditCardPrompts { get; set; }
        [StringLength(100)]
        public string OpHours { get; set; }
        [Column("InstallationSupplierID")]
        public int? InstallationSupplierId { get; set; }
        public int? NumberOfPumps { get; set; }
        public int? NumberPayAtPump { get; set; }
        public int? DebitAtPump { get; set; }
        [StringLength(10)]
        public string LayOut { get; set; }
        [Column(TypeName = "image")]
        public byte[] LayOutImage { get; set; }
        [Column("POSMaintenanceSupplierID")]
        public int? PosmaintenanceSupplierId { get; set; }
        [Column("POSMaintSupport")]
        [StringLength(50)]
        public string PosmaintSupport { get; set; }
        [Column("POSMaintSupportPhone")]
        [StringLength(15)]
        public string PosmaintSupportPhone { get; set; }
        [Column("POSDistRouter")]
        public int? PosdistRouter { get; set; }
        [StringLength(100)]
        public string OtherLoyaltyService { get; set; }
        [Column("RemoteAccessID")]
        [StringLength(15)]
        public string RemoteAccessId { get; set; }
        [Column("KioskOriginationDeviceID")]
        public int? KioskOriginationDeviceId { get; set; }
        [StringLength(20)]
        public string OriginationDeviceSerial { get; set; }
        [Column("InstallationOrigDevJobID")]
        public int? InstallationOrigDevJobId { get; set; }
        [Column("POSRouterBrand")]
        [StringLength(20)]
        public string PosrouterBrand { get; set; }
        [Column("ImageDocumentID")]
        public int? ImageDocumentId { get; set; }
        [Column("Dealer_ID")]
        [StringLength(50)]
        public string DealerId { get; set; }
        [Column("POSProductEntryMethods")]
        [StringLength(200)]
        public string PosproductEntryMethods { get; set; }
        public string Commments { get; set; }
        [StringLength(20)]
        public string VendorAccountNumber { get; set; }
        [Column("POSRouter")]
        [StringLength(30)]
        public string Posrouter { get; set; }
    }
}
