using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MerchantMVC.ViewModels
{
    public class EditLocationViewModel
    {
        [Key]
        public int LocationId { get; set; }

        public int? MerchantId { get; set; }

        [Display(Name = "Status")]
        public string LocationStatus { get; set; }

        public int? EntityCategoryId { get; set; }

        [Required(ErrorMessage ="Please enter Location Name.")]
        [Display(Name = "Location Name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter Address.")]
        [Display(Name = "Address 1")]
        public string LAddr1 { get; set; }

        [Display(Name = "Address 2")]
        public string LAddr2 { get; set; }


        [Required(ErrorMessage = "Please enter City.")]
        [Display(Name = "City")]
        public string LCity { get; set; }

        [Required(ErrorMessage = "Please enter State.")]
        [Display(Name = "State")]
        public string LState { get; set; }

        [Required(ErrorMessage = "Please enter Zip.")]
        [Display(Name = "ZIP")]
        public string LZip { get; set; }

        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email.")]
        [Display(Name = "Email")]
        public string EmailAddr { get; set; }

        [Display(Name = "Website")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Please enter First Name.")]
        [Display(Name = "Contact First Name")]
        public string LFname { get; set; }

        [Display(Name = "Contact Last Name")]
        [Required(ErrorMessage = "Please enter Last Name.")]
        public string LLname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter Phone.")]
        [Display(Name = "Phone")]
        public string LPhone { get; set; }

        public string Comments { get; set; }

        [Display(Name = "Store Number")]
        public string MerchantNumber { get; set; }

        //public string InternetServiceProvider { get; set; }
        //public string WifiSecurityType { get; set; }
        //public string WifiKey { get; set; }

        //public double? Latitude { get; set; }
        //public double? Longitude { get; set; }
        [Display(Name = "Timezone")]
        public int? TimeZone { get; set; }

        [Display(Name ="Store Brand")]
        public string Brand { get; set; }

        //properties below is for the tab in the edit location view
 
        public Tab ActiveTab { get; set; }

        public enum Tab
        {
            LoyaltyTransaction, CurrentTransaction, Batches, Terminal, SupportCalls
        }
    }
}
