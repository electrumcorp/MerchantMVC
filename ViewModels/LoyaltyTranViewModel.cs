using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MerchantMVC.ViewModels
{
    public class LoyaltyTranViewModel
    {
        [Key]
        public int LoyaltyTransactionId { get; set; }
        public int? LoyaltyDetailTerminalId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }
       public string UpdatedDateFormatted { get; set; } 
        public int? ItemId { get; set; }
        public string Item { get; set; }
        public decimal? Amount { get; set; }
       
        public decimal? Quantity { get; set; }
        
        public int? LoyaltyDetailId { get; set; }
        public decimal? Discount { get; set; }

        public int? CategoryId { get; set; }
        public  string CardName { get; set; }
        public string CategoryName { get; set; }
        public int? LocationId { get; set; }
       
       
    

        
    }
}
