using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class MerchantViewModel
    {
        [Key]
        public int MerchantId { get; set; }

        [Column("ProgramID")]
        public int? ProgramId { get; set; }

        [Column("M_NAME")]
        [StringLength(50)]
        [Required]
        [Display(Name = "Merchant Name")]
        public string MName { get; set; }

        [Column("M_FNAME")]
        [StringLength(20)]
        [Display(Name = "Contact First Name")]
        public string MFname { get; set; }

        [Column("M_LNAME")]
        [StringLength(20)]
        [Display(Name = "Contact Last Name")]
        public string MLname { get; set; }

        [Column("M_ADDR1")]
        [StringLength(30)]
        [Required]
        [Display(Name = "Address 1")]
        public string MAddr1 { get; set; }

        [Column("M_ADDR2")]
        [StringLength(30)]
        [Display(Name = "Address 2")]
        public string MAddr2 { get; set; }

        [Column("M_CITY")]
        [StringLength(20)]
        [Required]
        [Display(Name = "City")]
        public string MCity { get; set; }

        [Column("M_STATE")]
        [StringLength(2)]
        [Required]
        [Display(Name = "State")]
        public string MState { get; set; }

        [Column("M_ZIP")]
        [StringLength(10)]
        [Required]
        [Display(Name = "ZIP Code")]
        public string MZip { get; set; }

        [Column("M_PHONE")]
        [StringLength(15)]
        [Required]
        [Display(Name = "Phone")]
        public string MPhone { get; set; }

        [Column("M_EXTEN")]
        [StringLength(4)]
        public string MExten { get; set; }

        [StringLength(50)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Column("URLAddress")]
        [StringLength(50)]
        [Display(Name = "Website")]
        public string Urladdress { get; set; }

        [Column("TAX_ID")]
        [StringLength(11)]
        [Display(Name = "FEIN/Tax ID Number")]
        [Required]
        public string TaxId { get; set; }
        public enum Tab
        {
            Locations, LoyaltyTransaction, CurrentTransaction, Batches, Terminal, SupportCalls
        }
    }
}
