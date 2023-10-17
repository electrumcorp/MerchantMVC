using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class LocationActivate
    {
        [Key]
        public int LocationActivateId { get; set; }
        public int? EntityId { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? MerchantId { get; set; }
        public int? LocationId { get; set; }
        public string LName { get; set; }
        public string LAddr1 { get; set; }
        public string LAddr2 { get; set; }
        public string LCity { get; set; }
        public string LState { get; set; }
        public string LZip { get; set; }
        public int? CountryId { get; set; }
        public string Fax { get; set; }
        public string EmailAddr { get; set; }
        public string Url { get; set; }
        public string LPhone { get; set; }
        public string Rbankname { get; set; }
        public string RbankCity { get; set; }
        public string RAba { get; set; }
        public string RAcct { get; set; }
        public string RBatype { get; set; }
        public string Pbankname { get; set; }
        public string PbankCity { get; set; }
        public string LPaba { get; set; }
        public string LPbnkacct { get; set; }
        public string LPbatype { get; set; }
        public int? EmployeeId { get; set; }
        public int? CategoryId { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public int? MerchantActivateId { get; set; }
        public int? Approved { get; set; }
        public int? Imported { get; set; }
        public int? CardsOrdered { get; set; }
        public int? NumberTerminals { get; set; }
        public int? BatchCloseType { get; set; }
        public string MerchantNumber { get; set; }
        public string PayableTo { get; set; }
        public DateTime? EnrollDate { get; set; }
        public string PumpDispenserModel { get; set; }
        public string InternetServiceProvider { get; set; }
        public byte[] WifiSecurityType { get; set; }
        public string WifiKey { get; set; }
        public string LFname { get; set; }
        public string LLname { get; set; }
        public string FuelBrand { get; set; }
        public string StoreManagementSystem { get; set; }
        public string Possystem { get; set; }
        public string Posappplication { get; set; }
        public string PosapplicationVersion { get; set; }
        public string Poscard { get; set; }
        public string RackBarrelHeight { get; set; }
        public string PumpTopperSize { get; set; }
        public string SurgeProtection { get; set; }
        public string CreditCardAcquirer { get; set; }
        public string CardsAccpeted { get; set; }
        public string CreditCardPrompts { get; set; }
        public string OpHours { get; set; }
        public string InstallationSupplierId { get; set; }
        public string InstallationSupplier { get; set; }
        public string InstllationSupplierPhone { get; set; }
        public string InstallationSupplierEmail { get; set; }
        public int? NumberOfPumps { get; set; }
        public int? NumberPayAtPump { get; set; }
        public int? DebitAtPump { get; set; }
        public string LayOut { get; set; }
        public byte[] LayOutImage { get; set; }
        public int? PosmaintenanceSupplierId { get; set; }
        public string PosmaintSupport { get; set; }
        public string PosmaintSupportPhone { get; set; }
        public int? PosdistRouter { get; set; }
        public string OtherLoyaltyService { get; set; }
        public string PreparedbyName { get; set; }
        public string PreparedbyPhone { get; set; }
        public string PreparedbyEmail { get; set; }
        public DateTime? PreparedDate { get; set; }
        public string Siccode { get; set; }
        public string OpId { get; set; }
        public string TimeZone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? NetworkId { get; set; }
        public string AppCompletedByName { get; set; }
        public string AppCompletedByTitle { get; set; }
        public string AppCompletedByCo { get; set; }
        public string AppCompletedByPhone { get; set; }
        public string AppCompletedbyEmail { get; set; }
        public int? AppEntityCategoryId { get; set; }
        public int? AppId { get; set; }
        public string RemotePcid { get; set; }
        public int? DefaultOriginationDeviceId { get; set; }
        public int? ScanDataStatus { get; set; }
        public string Comments { get; set; }
        public int? FileFormatId { get; set; }
        public string PosrouterBrand { get; set; }
        public string PosproductEntryMethods { get; set; }
        public string VendorAccountNumber { get; set; }
    }
}
