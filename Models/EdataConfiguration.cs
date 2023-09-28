using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class EdataConfiguration
    {
        public int EdataConfigurationId { get; set; }
        public int? MerchantId { get; set; }
        public string MerchantContactName { get; set; }
        public string MerchantContactPhone { get; set; }
        public string MerchantContactEmail { get; set; }
        public int? ManufacturerId { get; set; }
        public int? AccountNumber { get; set; }
        public string SftpaddressPrimary { get; set; }
        public int? SftpprimaryPort { get; set; }
        public string SftpaddressSecondary { get; set; }
        public int? SftpsecondaryPort { get; set; }
        public string ExportFileNamePrefix { get; set; }
        public string ExportFileNameSuffix { get; set; }
        public int? EdataDataCategoryId { get; set; }
        public string Instructrions { get; set; }
        public int? EndWeekDay { get; set; }
        public int? SubmitDay { get; set; }
        public int? SubmitEntitryCategoryId { get; set; }
        public string Sftppassword { get; set; }
        public string SftpuserName { get; set; }
        public string AccountHeaderAbbrv { get; set; }
        public string AdminWebSite { get; set; }
        public string AdminWebUserName { get; set; }
        public string AdminWebPassword { get; set; }
        public string HelpDeskUrl { get; set; }
        public string HelpDeskPhone { get; set; }
        public string HelpDeskEmail { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int? SupplierId { get; set; }
        public int? StatusCategoryId { get; set; }
        public int? DefaultFileFormatId { get; set; }
        public int? SponsorId { get; set; }
        public DateTime? StartDate { get; set; }
        public string EdataSftpaddress { get; set; }
        public int? EdataSftpaddressPort { get; set; }
        public string EdataSftpuserName { get; set; }
        public string EdataSftppassword { get; set; }
        public string EdataWebAdminSite { get; set; }
        public string EdataWebAdminUn { get; set; }
        public string EdataWebAdminPw { get; set; }
        public string MerchantName { get; set; }
        public string ItcontactName { get; set; }
        public string ItcontactEmail { get; set; }
        public string ItcontactPhone { get; set; }
        public string SftpincomingDir { get; set; }
        public DateTime? EndDate { get; set; }
        public string BackOfficeSoftware { get; set; }
        public int? DefaultLoyaltyLocGroupId { get; set; }
        public int? UpccheckDigit { get; set; }
        public int? UpcleadingZero { get; set; }
        public int? SupplierSettlementId { get; set; }
        public int? LocationId { get; set; }
        public string ExportFileExtension { get; set; }
        public string AlcsdevPortalUsername { get; set; }
        public string AlcsdevPortalPassword { get; set; }
        public int? ScanDataReportingCategoryId { get; set; }
        public bool? FillLoyaltyIds { get; set; }
        public string DistributionEmail { get; set; }
        public int? AltriaManagementAccountNumber { get; set; }
        public int? DtptierCategoryId { get; set; }
    }
}
