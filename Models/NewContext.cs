using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class NewContext : DbContext
    {
        public NewContext()
        {
        }

        public NewContext(DbContextOptions<NewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MerchantActivate> MerchantActivates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=tcp:172.30.4.10;Database=Ebase5;Trusted_Connection=False;User Id=sqladmin;Password=sql@dm1n;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MerchantActivate>(entity =>
            {
                entity.Property(e => e.AcceptAgreement).IsUnicode(false);

                entity.Property(e => e.AchId).IsFixedLength(true);

                entity.Property(e => e.AppCompletedByCo).IsUnicode(false);

                entity.Property(e => e.AppCompletedByName).IsUnicode(false);

                entity.Property(e => e.AppCompletedByPhone).IsUnicode(false);

                entity.Property(e => e.AppCompletedByTitle).IsUnicode(false);

                entity.Property(e => e.AppCompletedbyEmail).IsUnicode(false);

                entity.Property(e => e.EntityCategoryId).HasDefaultValueSql("((57))");

                entity.Property(e => e.FedTaxId).IsFixedLength(true);

                entity.Property(e => e.MEdate).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
