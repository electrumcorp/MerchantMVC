using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Models
{
    public partial class CallTracking
    {
        [Key]
        public int CallTrackingId { get; set; }
        public int? Id { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Type { get; set; }
        public int? Priority { get; set; }
        public int? Assignment { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public int? CollectionStatusId { get; set; }
        public int? CompanyId { get; set; }
        public int? SalesOrgId { get; set; }
        public int? SponsorId { get; set; }
        public int? OpEntityCategoryId { get; set; }
        public int? OpEntityId { get; set; }
        public int? ServiceId { get; set; }
        public int? FunctionId { get; set; }
        public int? AlertId { get; set; }
        public string PromiseToPayAmt { get; set; }
        public string PromiseToPayDate { get; set; }
    }
}
