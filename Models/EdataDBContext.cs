using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class EdataDbContext : DbContext
    {
        public EdataDbContext()
        {
        }

        public EdataDbContext(DbContextOptions<EdataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EdataConfiguration> EdataConfiguration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=tcp:172.30.4.15;Database=Edata;Trusted_Connection=no;User Id=sqladmin;Password=sql@dm1n;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EdataConfiguration>(entity =>
            {
                entity.HasKey(e => e.EdataConfigurationId);

                entity.ToTable("EDataConfiguration_T_EC");

                entity.Property(e => e.EdataConfigurationId).HasColumnName("EdataConfigurationID");

                entity.Property(e => e.AccountHeaderAbbrv)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdminWebPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminWebSite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminWebUserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AlcsdevPortalPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ALCSDevPortalPassword");

                entity.Property(e => e.AlcsdevPortalUsername)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ALCSDevPortalUsername");

                entity.Property(e => e.BackOfficeSoftware)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultFileFormatId)
                    .HasColumnName("DefaultFileFormatID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultLoyaltyLocGroupId).HasColumnName("DefaultLoyaltyLocGroupID");

                entity.Property(e => e.DistributionEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DtptierCategoryId).HasColumnName("DTPTierCategoryID");

                entity.Property(e => e.EdataDataCategoryId)
                    .HasColumnName("EDataDataCategoryID")
                    .HasDefaultValueSql("('1212')");

                entity.Property(e => e.EdataSftpaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDataSFTPAddress");

                entity.Property(e => e.EdataSftpaddressPort).HasColumnName("EDataSFTPAddressPort");

                entity.Property(e => e.EdataSftppassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDataSFTPPassword");

                entity.Property(e => e.EdataSftpuserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDataSFTPUserName");

                entity.Property(e => e.EdataWebAdminPw)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDataWebAdminPW");

                entity.Property(e => e.EdataWebAdminSite)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("EDataWebAdminSite")
                    .HasDefaultValueSql("('https://electrumcorporation.com/LoyaltyAdministration/')");

                entity.Property(e => e.EdataWebAdminUn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDataWebAdminUN");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ExportFileExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExportFileNamePrefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExportFileNameSuffix)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('yyyymmdd')")
                    .IsFixedLength(true);

                entity.Property(e => e.FillLoyaltyIds)
                    .IsRequired()
                    .HasColumnName("FillLoyaltyIDs")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HelpDeskEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HelpDeskPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HelpDeskUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HelpDeskURL");

                entity.Property(e => e.Instructrions).IsUnicode(false);

                entity.Property(e => e.ItcontactEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITContactEmail");

                entity.Property(e => e.ItcontactName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITContactName");

                entity.Property(e => e.ItcontactPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITContactPhone");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.MerchantContactEmail)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.MerchantContactName)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.MerchantContactPhone)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MerchantName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScanDataReportingCategoryId).HasColumnName("ScanDataReportingCategoryID");

                entity.Property(e => e.SftpaddressPrimary)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SFTPAddressPrimary");

                entity.Property(e => e.SftpaddressSecondary)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SFTPAddressSecondary");

                entity.Property(e => e.SftpincomingDir)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SFTPIncomingDir");

                entity.Property(e => e.Sftppassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SFTPPassword");

                entity.Property(e => e.SftpprimaryPort)
                    .HasColumnName("SFTPPrimaryPort")
                    .HasDefaultValueSql("('22')");

                entity.Property(e => e.SftpsecondaryPort)
                    .HasColumnName("SFTPSecondaryPort")
                    .HasDefaultValueSql("('22')");

                entity.Property(e => e.SftpuserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SFTPUserName");

                entity.Property(e => e.SponsorId).HasColumnName("SponsorID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StatusCategoryId)
                    .HasColumnName("StatusCategoryID")
                    .HasDefaultValueSql("((186))");

                entity.Property(e => e.SubmitEntitryCategoryId)
                    .HasColumnName("SubmitEntitryCategoryID")
                    .HasDefaultValueSql("((57))");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SupplierSettlementId).HasColumnName("SupplierSettlementID");

                entity.Property(e => e.UpccheckDigit).HasColumnName("UPCCheckDigit");

                entity.Property(e => e.UpcleadingZero).HasColumnName("UPCLeadingZero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
