using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class EntityDocumentMerchantViewModel
    {
    [Key]
        public int DocumentsId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string DocumentUrl { get; set; }
    }
}
