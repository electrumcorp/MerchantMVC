using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchantMVC.ViewModels
{
    public class EditLocationViewModel
    {
        [Key]
        public int LocationId { get; set; }
        public int? CategoryId { get; set; }
        public int? MerchantId { get; set; }

        [Display(Name = "Status")]
        public string LocationStatus { get; set; }

        public int? EntityCategoryId { get; set; }

        [Required(ErrorMessage ="Please enter Location Name.")]
        [Display(Name = "Location Name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter Address 1.")]
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

        [Required(ErrorMessage = "Please enter Contact First Name.")]
        [Display(Name = "Contact First Name")]
        public string LFname { get; set; }

        [Display(Name = "Contact Last Name")]
        [Required(ErrorMessage = "Please enter Contact Last Name.")]
        public string LLname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter Phone.")]
        [Display(Name = "Phone")]
        public string LPhone { get; set; }

        public string Comments { get; set; }

        [Display(Name = "Store Number")]
        [Required(ErrorMessage = "Please enter Store Number.")]
        public string MerchantNumber { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [Display(Name ="Store Brand")]
        [Required]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter Fuel Brand.")]
        public string FuelBrand { get; set; }
        [Required(ErrorMessage = "Please enter POS Support Contact.")]
        public string PosmaintSupport { get; set; }
        [Required(ErrorMessage = "Please enter POS Support Number.")]
        public string PosmaintSupportPhone { get; set; }
        public int? CountryId { get; set; }

        [Display(Name = "Timezone")]
        public int? TimeZone { get; set; }
        [Display(Name = "POS Origination Device")]
        public int? DefaultOriginationDeviceId { get; set; }

        [NotMapped]
        public Tab ActiveTab { get; set; }
        public enum Tab
        {
            LoyaltyTransaction, CurrentTransaction, Batches, Terminal, SupportCalls
        }

        //public EditLocationViewModel()
        //{
        //    AvailableTimezones = new List<SelectListItem>()
        //    {
        //        new SelectListItem{ Text = "Eastern (GMT-5)", Value = "-5"},
        //        new SelectListItem{ Text = "Central (GMT-6)", Value = "-6"},
        //        new SelectListItem{ Text = "Mountain (GMT-7)", Value = "-7"},
        //        new SelectListItem{ Text = "Pacific (GMT-8)", Value = "-8"},
        //        new SelectListItem{ Text = "Alaska (GMT-9)", Value = "-9"},
        //        new SelectListItem{ Text = "Hawaii-Aleutian (GMT-10)", Value = "-10"}
        //    };

        //    AvailableOriginationDevices = new List<SelectListItem>()
        //    {
        //        new SelectListItem{ Text = "Gilbarco Passport", Value = "19"},
        //        new SelectListItem{ Text = "Gilbarco Passport", Value = "22"}
        //    };
        //}
    }
}
