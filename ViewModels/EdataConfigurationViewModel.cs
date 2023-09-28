using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class EdataConfigurationViewModel
    {
        public int EdataConfigurationId { get; set; }
        public int? MerchantId { get; set; }
        public string MerchantContactName { get; set; }
        public string MerchantContactPhone { get; set; }
        public string MerchantContactEmail { get; set; }
        public int? ManufacturerId { get; set; }
        public int? AccountNumber { get; set; }
        public string ExportFileNamePrefix { get; set; }
        public string AdminWebSite { get; set; }
        public string AdminWebUserName { get; set; }
        public string AdminWebPassword { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int? SponsorId { get; set; }
        public string EdataSftpuserName { get; set; }
        public string EdataSftppassword { get; set; }
        public string EdataWebAdminSite { get; set; }
        public string EdataWebAdminUn { get; set; }
        public string ItcontactName { get; set; }
        public string ItcontactEmail { get; set; }
        public string ItcontactPhone { get; set; }
        public int? DtptierCategoryId { get; set; }
    }
}
