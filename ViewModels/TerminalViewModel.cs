using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;

namespace MerchantMVC.ViewModels
{
    public class TerminalViewModel
    {
    [Key]
        public int Terminal30Id { get; set; }
        public int? MerchantId { get; set; }
        public int? LocationId { get; set; }
        public string TId { get; set; }
        public string TermDescrip { get; set; }
        public string Status { get; set; }
        //public virtual ICollection<Tapbatch> Tapbatches { get; set; }
    }
}
