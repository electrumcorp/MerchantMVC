using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Models
{
    public partial class Terminal
    {
        public Terminal()
        {
            Tapbatches = new HashSet<Tapbatch>();
        }

        [Key]
        public int Terminal30Id { get; set; }
        public int? MerchantId { get; set; }
        public int? LocationId { get; set; }
        public string TId { get; set; }
        public string TSerial { get; set; }
        public string TermDescrip { get; set; }
        public string Status { get; set; }
        public int? OriginationDeviceId { get; set; }
        public int? ApplicationId { get; set; }
        public int? NetworkId { get; set; }
        public string NetworkTid { get; set; }
        public int? ProcessorId { get; set; }
        public string ProcessorTId { get; set; }
        public int? SalesRepId { get; set; }
        public int BatchCloseTypeId { get; set; }
        public string ShortDescrip { get; set; }
        public int? CategoryId { get; set; }
        public int? SubServiceId { get; set; }
        public DateTime? CloseTime { get; set; }
        public int? ServiceContractId { get; set; }
        public string TCic { get; set; }
        public DateTime? AddDate { get; set; }
        public int? TimeZoneId { get; set; }
        public int? SeccCategoryId { get; set; }
        public int? TeamViewerId { get; set; }
        public int? CreatedBy { get; set; }
        public int? CreatedByEntityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UpdatedByEntityId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string SoftwareVersion { get; set; }
        public string CascadingStyleSheet { get; set; }

        public virtual ICollection<Tapbatch> Tapbatches { get; set; }
    }
}
