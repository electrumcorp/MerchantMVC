using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class MerchantProfileViewModel
    {
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

        [Column("SponsorID")]
        public int? SponsorId { get; set; }

        [Column("EDataConfigurationID")]
        public int? EdataConfigurationId { get; set; }
    }
}
