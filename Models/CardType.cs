using System;
using System.Collections.Generic;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class CardType
    {
        public CardType()
        {
            Cards = new HashSet<Card>();
        }

        public int CardTypeId { get; set; }
        public int? ServiceId { get; set; }
        public string CardTypeName { get; set; }
        public string IssuerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string CardPhone { get; set; }
        public string MerchantPhone { get; set; }

        public virtual Service Service { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
