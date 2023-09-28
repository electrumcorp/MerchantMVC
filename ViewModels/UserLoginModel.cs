using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class UserLoginModel
    { 
        [Required(ErrorMessage="Please enter Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string password { get; set; }
        public string CategoryName { get; set; }
        public string TableColumn { get; set; }
        public string FullName { get; set; }
        public int CategoryId { get; set; }
        public bool IsValidUser { get; set; }
        //to  store locationid /merchant id
        public int LocationID { get; set; }
        public int MerchantId { get; set; }
        public int EmployeeId { get; set; }
        public int Id { get; set; }

    }
}
