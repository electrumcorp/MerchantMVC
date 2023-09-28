using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Models
{
    public partial class Permission
    {
        public int PermissionId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? CategoryId { get; set; }
        public int? Id { get; set; }
        public int? RelationshipCategoryId { get; set; }
        public int? RelationshipId { get; set; }
        public string Email { get; set; }
        public int? EmployeeId { get; set; }
        public int? PositionId { get; set; }
        public string SecretWord { get; set; }
        public int? SecretWordCategoryId { get; set; }
        public int? ServiceId { get; set; }
        public string MIdnum { get; set; }
        public int? MerchantId { get; set; }
        public int? LocationId { get; set; }
        public int? CustomerId { get; set; }
        public string CIdnum { get; set; }
        public int? CardId { get; set; }
        public int? ClientId { get; set; }
        public string HomePage { get; set; }
        public int? SalesOrgId { get; set; }
        public int? SalesRepId { get; set; }
        public string Dsn { get; set; }
        public string Role { get; set; }
        public DateTime? CreateDate { get; set; }
        public int AccessFailedCount { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool? LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public int? AlternateId { get; set; }
    }
}
