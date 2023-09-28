using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public int? Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get { return string.Concat(FirstName, " ", LastName); } }
    }
    
}
