using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class EditCallTrackingViewModel
    {
        public int CallTrackingId { get; set; }
        public int? Id { get; set; }
        public int? EntityCategoryId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? TrackingDateTime { get; set; }
        public int? TrackingType { get; set; }
        public int? PriorityID { get; set; }
        public string Priority { get; set; }

        public string Comment { get; set; }
        public string CategoryName { get; set; }
        public int? StatusID { get; set; }
        public string Status { get; set; }
        public string EmployeeName { get; set; }
        //Employees
        public IEnumerable<SelectListItem> Employees { get; set; }
        //Priority
        public IEnumerable<SelectListItem> Priorities { get; set; }
        //Status
        public IEnumerable<SelectListItem> StatusItems { get; set; }
    }
}
