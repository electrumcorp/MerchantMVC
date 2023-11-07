using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MerchantMVC.Models;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantMVC.ViewModels
{
    public class VirtualTerminalViewModel
    {
        [Key]
        public Guid VirtualTerminalID { get; set; }
        public int LocationID { get; set; }

        [Required(ErrorMessage = "Terminal is required")]
        public int Terminal30ID { get; set; }

        [MinLength(14, ErrorMessage = "Card Account Number must be at least 14 digits")]
        [Required(ErrorMessage = "Card Account Number is required")]
        public string CardAccountNumber { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Card Type is required")]
        public int CardTypeID { get; set; }

        [Required(ErrorMessage = "Transaction Code is required")]
        public int TransCodeID { get; set; }

        public int TransactionTypeID { get; set; }

        public string ReferenceID { get; set; }

        public string ReferenceType { get; set; }

        public string TransactionComments { get; set; }

        // navigation properties
        public Terminal Terminal { get; set; }

        // drop down lists properties
        [NotMapped]
        public string SelectedLocation { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> LocationsList { get; set; }
        [NotMapped]
        public string SelectedTerminal { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> TerminalsList { get; set; }
        [NotMapped]
        public string SelectedCardType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CardTypeList { get; set; }
        [NotMapped]
        public string SelectedTransCode { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> TransCodeList { get; set; }
        [NotMapped]
        public string SelectedReferenceType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ReferenceTypeList { get; set; }

    }
}
