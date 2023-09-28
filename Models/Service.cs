using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Service
    {
        public Service()
        {
            CardTypes = new HashSet<CardType>();
            Programs = new HashSet<Program>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string Urladdress { get; set; }
        public int? SettlementCategoryId { get; set; }

        public virtual ICollection<CardType> CardTypes { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
    }
}
