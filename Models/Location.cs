using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public int? EntityId { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? MerchantId { get; set; }
        public int? PersonId { get; set; }
        public int? TerminalId { get; set; }
        public string PropCode { get; set; }
        public string AccountNumber { get; set; }
        public string LocationStatus { get; set; }
        public string LFam { get; set; }
        public string MIdnum { get; set; }
        public string LIdnum { get; set; }
        public string LCic { get; set; }
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
        public string LFname { get; set; }
        public string LLname { get; set; }
        public string LPhoneold { get; set; }
        public string LPhone { get; set; }
        public string LExt { get; set; }
        public string LAchid { get; set; }
        public string Rbankname { get; set; }
        public string RAba { get; set; }
        public string RAcct { get; set; }
        public string RBatype { get; set; }
        public int? CheckCollMerchantId { get; set; }
        public string Cbankname { get; set; }
        public string LAba { get; set; }
        public string LBnkacct { get; set; }
        public string LBatype { get; set; }
        public string Pbankname { get; set; }
        public string LPaba { get; set; }
        public string LPbnkacct { get; set; }
        public string LPbatype { get; set; }
        public string OpId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string TransactionLimit { get; set; }
        public string DailyHighVolume { get; set; }
        public decimal? RejectServiceFee { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Comments { get; set; }
        public decimal? ReserveOtb { get; set; }
        public int? LocationActivateId { get; set; }
        public string MerchantNumber { get; set; }
        public int? CategoryId { get; set; }
        public int? CbterminalId { get; set; }
        public int? AchfileCatId { get; set; }
        public string Achid { get; set; }
        public int? AchbatchHeaderType { get; set; }
        public string PumpDispenserModel { get; set; }
        public string InternetServiceProvider { get; set; }
        public byte[] WifiSecurityType { get; set; } = null;
        public string WifiKey { get; set; }
        public string LocationCommissionAccount { get; set; }
        public string Siccode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? TimeZone { get; set; }
        public string Brand { get; set; }
        public bool? KioskDlparseSupport { get; set; }
        public int? RemotePcid { get; set; }
        public string DealerId { get; set; }
        public int? DefaultOriginationDeviceId { get; set; }
        public bool? DaylightSavingTime { get; set; }
        public int? FileFormatId { get; set; }
        public int? DefaultBatchCloseTypeId { get; set; }
        public int? ScanDataStatus { get; set; }
        public string StoreHours { get; set; }
    }
}
