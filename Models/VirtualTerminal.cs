using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Models
{
    public class VirtualTerminal
    {
        [Key]
        public Guid VirtualTerminalID { get; set; }
        public int LocationID { get; set; }
        public int Terminal30ID { get; set; }
        public int CardAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceID { get; set; }
        public string TransactionComments { get; set; }

        //// navigation properties
        public Location Location { get; set; }
        public Terminal Terminal { get; set; }
        public TerminalCardType CardType { get; set; }
        public TerminalTranCode TranCode { get; set; }
        public Category ReferenceType { get; set; }
    }
}
