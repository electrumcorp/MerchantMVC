using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MerchantMVC.ViewModels
{
    public class FeedBackViewModel
    {
        [Key]
        [Column("FeedBackID")]
        public int FeedBackId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column("FunctionID")]
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
