using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class CallTrackingViewModel
    {
        public int CallTrackingId { get; set; }

        public int? Id { get; set; }

        public int? EntityCategoryId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime? TrackingDateTime { get; set; }

        [Display(Name = "Date")]
        public string TrackingDTFormatted { get; set; }

        // [Required(ErrorMessage = "Select Type")]
        [Display(Name = "Type")]
        public int? TrackingType { get; set; }

        [NotMapped]
        public string TrackingTypeName { get; set; }

        [Required(ErrorMessage="Select Priority")]
        public int? PriorityID { get; set; }
        [NotMapped]
        [Display(Name = "Priority")]
        public string PriorityName { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Priority { get; set; }

        [Required(ErrorMessage = "Please provide comment")]
        public string Comment { get; set; }

        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Select Status")]
        public int? StatusID { get; set; }

        [NotMapped]
        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Status { get; set; }

        [Display(Name = "Employee")]
        public string EmployeeName { get; set; }

    }
}
