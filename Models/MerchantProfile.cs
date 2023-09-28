using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MerchantMVC.Models
{
    [Table("MerchantProfile_T_EC")]
    public partial class MerchantProfile
    {
        [Key]
        [Column("MerchantProfileID")]
        public int MerchantProfileId { get; set; }
        [Column("MerchantID")]
        public int MerchantId { get; set; }
        [StringLength(50)]
        public string AccountNumber { get; set; }
        [Column("EntityCategoryID")]
        public int? EntityCategoryId { get; set; }
        [Column("ID")]
        public int? Id { get; set; }
        [Column("ProfileCategoryID")]
        public int? ProfileCategoryId { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}
