using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class Processor
    {
        public Processor()
        {
            Programs = new HashSet<Program>();
        }

        public int ProcessorId { get; set; }
        public string ProcessorName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public bool? VisaMasterCard { get; set; }
        public bool? AmericanExpress { get; set; }
        public bool? Discover { get; set; }
        public bool? DinersCarteBlanche { get; set; }
        public bool? PrivateLable { get; set; }
        public bool? PArc { get; set; }
        public bool? PEcard { get; set; }
        public bool? PEcheck { get; set; }
        public string PHelpphon { get; set; }
        public string PHelpfax { get; set; }
        public string PServphon { get; set; }
        public string PServfax { get; set; }
        public string PSupphon { get; set; }
        public string PSuppfax { get; set; }
        public string PChrgphon { get; set; }
        public string PChrgfax { get; set; }
        public string SalesContact { get; set; }
        public string SalesContactPhone { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int? EntityCategoryId { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
