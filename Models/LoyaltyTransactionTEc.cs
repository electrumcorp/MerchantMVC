using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class LoyaltyTransactionTEc
    {
        public int LoyaltyTransactionId { get; set; }
        public int? LoyaltyDetailTerminalId { get; set; }
        public int? CardId { get; set; }
        public int? TransactionId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Points { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? ItemId { get; set; }
        public string Item { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Factor { get; set; }
        public decimal? Value { get; set; }
        public decimal? Quantity { get; set; }
        public int? CardActivateId { get; set; }
        public int? LoyaltyDetailId { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Chances { get; set; }
        public string Message { get; set; }
        public decimal? RequiredPoints { get; set; }
        public string LoyaltyCouponNumber { get; set; }
        public string Descriptor { get; set; }
        public int? LocationId { get; set; }
        public Guid? LoyaltyRewardId { get; set; }
        public int? LineNumber { get; set; }
        public decimal? OriginalDiscount { get; set; }
        public string ChangeReason { get; set; }
        public int? PendingDiscountId { get; set; }
        public string FuelGradeId { get; set; }
        public int? RedemptionLoyaltyTransactionId { get; set; }
        public decimal? RedemptionAmount { get; set; }
        public string PostransactionId { get; set; }
        public int? LoyaltyDetailRewardSkugroupId { get; set; }
        public int? LoyaltySkugroupId { get; set; }
        public int? LoyaltyLocationGroupId { get; set; }
        public int? LoyaltyProgramId { get; set; }
        public string PromoText { get; set; }
        public string Posnum { get; set; }
        public int? LoyaltyVendorId { get; set; }
        public string Upc { get; set; }
        public Guid? ResponseLoyaltySequenceId { get; set; }
        public int? ClubCount { get; set; }

        public virtual Card Card { get; set; }
    }
}
