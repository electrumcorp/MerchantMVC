using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MerchantMVC.Models
{
    [Table("FeedBack_T_EC")]
    public partial class FeedBack
    {
        [Key]
        [Column("FeedBackID")]
        public int FeedBackId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column("FunctionID")]
        public int? FunctionId { get; set; }
        [Column("ServiceID")]
        public int? ServiceId { get; set; }
        [Column("RequestorEntityCategoryID")]
        public int? RequestorEntityCategoryId { get; set; }
        [Column("RequestorID")]
        public int? RequestorId { get; set; }
        [Column("RespondentEntityCategoryID")]
        public int? RespondentEntityCategoryId { get; set; }
        [Column("RespondentID")]
        public int? RespondentId { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        public string Question { get; set; }
        public bool? TrueFalse { get; set; }
        public string Answer { get; set; }
        [Column("StatusCategoryID")]
        public int? StatusCategoryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResponseDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EntryDate { get; set; }
        [Column("ResponseSourceID")]
        public int? ResponseSourceId { get; set; }
        [Column("ParentFeedbackID")]
        public int? ParentFeedbackId { get; set; }
        public string Notes { get; set; }
        public int? Ordinal { get; set; }
    }
}
