using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class TerminalTranCode
    {
    [Key]
        public int TranCodeId { get; set; }
        public string TranCode { get; set; }
        public string TranCodeName { get; set; }
    }
}
