using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MerchantMVC.Models
{
    [Table("EntityDocumentMerchant_V_EC")]
    public partial class EntityDocumentMerchant
    {
        [Key]
        [Column("DocumentsID")]
        public int DocumentsId { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        public string Content { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [Column("VideoURL")]
        [StringLength(200)]
        public string VideoUrl { get; set; }
        public byte[] Image { get; set; }
        [Column("HTMLContent")]
        public string Htmlcontent { get; set; }
        [Column("FunctionID")]
        public int? FunctionId { get; set; }
        [StringLength(50)]
        public string FunctionName { get; set; }
        [Column("CloudStorageURL")]
        [StringLength(200)]
        public string CloudStorageUrl { get; set; }
        [Column("ID")]
        public int? Id { get; set; }
        [Column("EntityCategoryID")]
        public int? EntityCategoryId { get; set; }
    }
}
