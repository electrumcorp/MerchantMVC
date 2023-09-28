using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Models
{
    public partial class Tapbatch
    {
        public int TapbatchId { get; set; }
        public int? TerminalId { get; set; }
        public int? CaptureId { get; set; }
        public int? TransactionCount { get; set; }
        public decimal? BatchAmount { get; set; }
        public DateTime? CutoffDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string BatchType { get; set; }
        public string ReqCode { get; set; }
        public string PrinterInfo { get; set; }
        public int? BatchCloseCategoryId { get; set; }

        public virtual Terminal Terminal { get; set; }
    }
}
