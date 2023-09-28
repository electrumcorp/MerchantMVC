using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class BatchViewModel
    {
        public int TapbatchId { get; set; }
        public int? TerminalId { get; set; }
        public int? CaptureId { get; set; }
        public int? TransactionCount { get; set; }
        public decimal? BatchAmount { get; set; }
        public DateTime? CutoffDate { get; set; }
        public string FormattedCuttOffDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string TerminalDescription { get; set; }
        public int LocationId { get; set; }
    }
}
