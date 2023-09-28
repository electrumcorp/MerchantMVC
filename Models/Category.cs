using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryTableId { get; set; }
        public int? TypeId { get; set; }
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string TableColumn { get; set; }
    }
}
