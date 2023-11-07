using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MerchantMVC.Models
{
    public class TerminalCardType
    {
        public int Terminal30Id { get; set; }
        public int CardTypeId { get; set; }
        public string CardTypeName { get; set; }
    }
}
