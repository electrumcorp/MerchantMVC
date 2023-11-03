using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class TerminalTranCode
    {
    [Key]
        public string TranCode { get; set; }
        public int TranCodeId { get; set; }
        public string TranCodeName { get; set; }
    }
}
