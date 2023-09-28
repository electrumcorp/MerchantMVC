using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MerchantMVC.ViewModels;
using Microsoft.Extensions.Configuration;
using MerchantMVC.Models;

#nullable disable

namespace MerchantMVC.Models
{
    public partial class EbaseDBContext : DbContext
    {      
        public EbaseDBContext()
        {
            
        }

        public EbaseDBContext(DbContextOptions<EbaseDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Tapbatch> Tapbatches { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<CallTracking> CallTrackings { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }        
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }        
        public virtual DbSet<LoyaltyTransactionTEc> LoyaltyTransactionTEcs { get; set; }
        public virtual DbSet<Processor> Processors { get; set; }
        public virtual DbSet<Program> Programs { get; set; }        
        public virtual DbSet<Service> Services { get; set; }        
        public virtual DbSet<Sponsor> Sponsors { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<LocationProfile> LocationProfiles { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<MerchantProfile> MerchantProfiles { get; set; }
        public virtual DbSet<MerchantActivate> MerchantActivates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // production CS
                //optionsBuilder.UseSqlServer("server=tcp:172.30.4.10;Database=Ebase5;Trusted_Connection=no;User Id=sqladmin;Password=sql@dm1n;");// ;

                // dev CS
                optionsBuilder.UseSqlServer("server=tcp:172.30.4.14;Database=Ebase5;Trusted_Connection=no;User Id=sqladmin;Password=sql@dm1n;");// ;
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

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissionId);

                entity.ToTable("Permission");

                entity.HasIndex(e => new { e.UserName, e.Password }, "IDX_UserNamePw")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.Id, e.CategoryId }, "PermissionIDEntity")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.UserName, e.Password }, "UC_Permission_Username_Password")
                    .IsUnique();

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.AlternateId).HasColumnName("AlternateID");

                entity.Property(e => e.CIdnum)
                    .HasMaxLength(50)
                    .HasColumnName("C_IDNUM");

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Dsn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DSN");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.HomePage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LockoutEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.MIdnum)
                    .HasMaxLength(6)
                    .HasColumnName("M_Idnum");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.RelationshipCategoryId).HasColumnName("RelationshipCategoryID");

                entity.Property(e => e.RelationshipId).HasColumnName("RelationshipID");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesOrgId).HasColumnName("SalesOrgID");

                entity.Property(e => e.SalesRepId).HasColumnName("SalesRepID");

                entity.Property(e => e.SecretWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecretWordCategoryId).HasColumnName("SecretWordCategoryID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryTableId);

                entity.HasIndex(e => e.CategoryId, "UC_Categories_CategoryID")
                    .IsUnique();

                entity.Property(e => e.CategoryTableId).HasColumnName("CategoryTableID");

                entity.Property(e => e.CategoryDescription).HasMaxLength(500);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.TableColumn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.AchfileCategoryId).HasColumnName("ACHFileCategoryID");

                entity.Property(e => e.Bank1)
                    .HasMaxLength(50)
                    .HasColumnName("Bank");

                entity.Property(e => e.BillingAddress).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CleariingAba)
                    .HasMaxLength(10)
                    .HasColumnName("CleariingABA")
                    .IsFixedLength(true);

                entity.Property(e => e.ClearingAccount)
                    .HasMaxLength(17)
                    .IsFixedLength(true);

                entity.Property(e => e.CommunicationsHelp).HasMaxLength(30);

                entity.Property(e => e.CommunicationsPhone).HasMaxLength(30);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyOrDepartment).HasMaxLength(50);

                entity.Property(e => e.ContactFirstName).HasMaxLength(30);

                entity.Property(e => e.ContactLastName).HasMaxLength(50);

                entity.Property(e => e.ContactTitle).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(35);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EntityCategoryId)
                    .HasColumnName("EntityCategoryID")
                    .HasDefaultValueSql("((62))");

                entity.Property(e => e.Extension).HasMaxLength(30);

                entity.Property(e => e.FaxNumber).HasMaxLength(30);

                entity.Property(e => e.FileHelp).HasMaxLength(30);

                entity.Property(e => e.FileIdModifier).HasMaxLength(1);

                entity.Property(e => e.Ftpaddress)
                    .HasMaxLength(50)
                    .HasColumnName("FTPAddress");

                entity.Property(e => e.ImmediateDestination).HasMaxLength(10);

                entity.Property(e => e.ImmediateDestinationName).HasMaxLength(23);

                entity.Property(e => e.ImmediateOrigin).HasMaxLength(10);

                entity.Property(e => e.ImmediateOriginName).HasMaxLength(23);

                entity.Property(e => e.InstitutionNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.OriginatingDfiidentification)
                    .HasMaxLength(8)
                    .HasColumnName("OriginatingDFIIdentification");

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.ReserveTerminalId).HasColumnName("ReserveTerminalID");

                entity.Property(e => e.SalesContact).HasMaxLength(50);

                entity.Property(e => e.SalesPhone).HasMaxLength(50);

                entity.Property(e => e.StateOrProvince).HasMaxLength(20);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .HasColumnName("URL");
            });



            modelBuilder.Entity<CallTracking>(entity =>
            {
                entity.HasKey(e => e.CallTrackingId);

                entity.ToTable("CallTracking");

                entity.HasIndex(e => new { e.Id, e.EmployeeId, e.EntityCategoryId, e.Status, e.Priority, e.DateTime }, "CallTracking_Index1")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.DateTime, "missing_index_54813");

                entity.Property(e => e.CallTrackingId).HasColumnName("CallTrackingID");

                entity.Property(e => e.AlertId).HasColumnName("AlertID");

                entity.Property(e => e.CollectionStatusId).HasColumnName("CollectionStatusID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EntityCategoryId).HasColumnName("EntityCategoryID");

                entity.Property(e => e.FunctionId).HasColumnName("FunctionID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OpEntityCategoryId).HasColumnName("OpEntityCategoryID");

                entity.Property(e => e.OpEntityId).HasColumnName("OpEntityID");

                entity.Property(e => e.PromiseToPayAmt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromiseToPayDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesOrgId).HasColumnName("SalesOrgID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.SponsorId).HasColumnName("SponsorID");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card");

                entity.HasIndex(e => new { e.CardId, e.AccountNumber, e.CustomerId }, "Card_Index_1")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CardId, e.ServiceContractId }, "IX_CardIDServiceContractID")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CardId, e.ChDob }, "IX_CardID_CH_DOB")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CardId, e.EntityCategoryId }, "IX_CardID_EntityCategoryID_ProgramID");

                entity.HasIndex(e => e.ProgramId, "IX_Card_2");

                entity.HasIndex(e => e.ChHphone, "IX_Card_CH_HPHONE")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.IssuerId, "IX_Card_IssuerID")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.ChMphone, e.ProgramId, e.ChStatus, e.CardId, e.ChHphone, e.AddDate }, "IX_Card_PhoneNumberLookup2")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.ChHzip, "_dta_index_Card_5_876282627__K44_1")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.ProgramId, "_dta_index_Card_5_876282627__K4_1_33_71_92")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CountryId, e.CardId, e.EntityCategoryId, e.AccountNumber }, "_dta_index_Card_5_876282627__K73_K1_K3_K20_37_39");

                entity.HasIndex(e => new { e.CustomerId, e.ChStatus, e.CardRelationshipCategoryId }, "_dta_index_Card_5_876282627__K7_K24_K90_1_4_20_37_39_71")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.LocationId, e.ProgramId, e.ChStatus, e.CardId }, "_dta_index_Card_7_876282627__K13_K4_K24_K1")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.EntityId, e.CardId }, "_dta_index_Card_7_876282627__K2_K1_7_19_20_91");

                entity.HasIndex(e => new { e.ProgramId, e.ChStatus, e.CardId, e.EnrollmentLocationId, e.ChLname }, "_dta_index_Card_7_876282627__K4_K24_K1_K92_K39_20_37_40_41_42_43_44_45_67")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.ProgramId, "_dta_index_Card_8_926886619__K4_97");

                entity.HasIndex(e => new { e.ProgramId, e.DlNum }, "_dta_index_Card_8_926886619__K4_K53_1_24")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.AccountNumber, "missing_index_2_1");

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.AcctNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_NUM");

                entity.Property(e => e.AchposttDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACHPosttDate");

                entity.Property(e => e.ActivateId).HasColumnName("ActivateID");

                entity.Property(e => e.ActivationCategoryId).HasColumnName("ActivationCategoryID");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Adults).HasColumnName("ADULTS");

                entity.Property(e => e.AssociatedCardId).HasColumnName("AssociatedCardID");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.BillCardDate).HasColumnType("datetime");

                entity.Property(e => e.BillPayExternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BillPayExternalID");

                entity.Property(e => e.CIdnum)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("C_IDNUM");

                entity.Property(e => e.CardBinId).HasColumnName("CardBinID");

                entity.Property(e => e.CardIdassignDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CardIDAssignDate");

                entity.Property(e => e.CardIssuerId).HasColumnName("CardIssuerID");

                entity.Property(e => e.CardMag)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.CardRelationshipCategoryId).HasColumnName("CardRelationshipCategoryID");

                entity.Property(e => e.CardTypeId).HasColumnName("CardTypeID");

                entity.Property(e => e.ChAcct)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CH_ACCT");

                entity.Property(e => e.ChCcexp)
                    .HasColumnType("datetime")
                    .HasColumnName("CH_CCEXP");

                entity.Property(e => e.ChCcnum)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("CH_CCNUM");

                entity.Property(e => e.ChCctype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CH_CCTYPE");

                entity.Property(e => e.ChDob)
                    .HasColumnType("datetime")
                    .HasColumnName("CH_DOB");

                entity.Property(e => e.ChEdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CH_EDATE");

                entity.Property(e => e.ChFname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CH_FNAME");

                entity.Property(e => e.ChHaddr1)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CH_HADDR1");

                entity.Property(e => e.ChHaddr2)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CH_HADDR2");

                entity.Property(e => e.ChHcity)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CH_HCITY");

                entity.Property(e => e.ChHphone)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CH_HPHONE");

                entity.Property(e => e.ChHstate)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CH_HSTATE");

                entity.Property(e => e.ChHzip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CH_HZIP");

                entity.Property(e => e.ChInitial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CH_INITIAL");

                entity.Property(e => e.ChLname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CH_LNAME");

                entity.Property(e => e.ChMphone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CH_MPHONE");

                entity.Property(e => e.ChNotes)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("CH_NOTES");

                entity.Property(e => e.ChOtb)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CH_OTB");

                entity.Property(e => e.ChPadotb)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CH_PADOTB");

                entity.Property(e => e.ChPrefix)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CH_PREFIX");

                entity.Property(e => e.ChSalut)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CH_SALUT");

                entity.Property(e => e.ChSsn)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CH_SSN");

                entity.Property(e => e.ChStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CH_STATUS");

                entity.Property(e => e.ChWaddr1)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CH_WADDR1");

                entity.Property(e => e.ChWaddr2)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CH_WADDR2");

                entity.Property(e => e.ChWcity)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CH_WCITY");

                entity.Property(e => e.ChWphone)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CH_WPHONE");

                entity.Property(e => e.ChWstate)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CH_WSTATE");

                entity.Property(e => e.ChWzip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CH_WZIP");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.CommunicationsDeliveryCategoryId)
                    .HasColumnName("CommunicationsDeliveryCategoryID")
                    .HasDefaultValueSql("((902))");

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CpCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CP_CODE");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DlNum)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DL_NUM");

                entity.Property(e => e.DlState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DL_STATE");

                entity.Property(e => e.Education)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EDUCATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmailConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailValidationCategoryId).HasColumnName("EmailValidationCategoryID");

                entity.Property(e => e.EmailValidationPointsAwarded).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EnrollmentLocationId).HasColumnName("EnrollmentLocationID");

                entity.Property(e => e.EntityCategoryId).HasColumnName("EntityCategoryID");

                entity.Property(e => e.EntityId).HasColumnName("EntityID");

                entity.Property(e => e.FirstLoadTransEnterEdid).HasColumnName("FirstLoadTransEnterEDID");

                entity.Property(e => e.FirstTransactionDate).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Income)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("INCOME");

                entity.Property(e => e.IssuerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IssuerID");

                entity.Property(e => e.Ivrwebpin)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("IVRWEBPIN");

                entity.Property(e => e.LIdnum)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("L_IDNUM")
                    .IsFixedLength(true);

                entity.Property(e => e.LastTransDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.MIdnum)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("M_IDNUM")
                    .IsFixedLength(true);

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MobileAppLinkDate).HasColumnType("datetime");

                entity.Property(e => e.MobilePhoneValidationCategoryId).HasColumnName("MobilePhoneValidationCategoryID");

                entity.Property(e => e.MobilePhoneValidationPointsAwarded).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayEnableDate).HasColumnType("datetime");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Phonefax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phonefax");

                entity.Property(e => e.Pin)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PIN");

                entity.Property(e => e.PreviousCustomerId).HasColumnName("PreviousCustomerID");

                entity.Property(e => e.PrivacyLevel).HasDefaultValueSql("((330))");

                entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

                entity.Property(e => e.Reserved1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED1");

                entity.Property(e => e.Reserved2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED2");

                entity.Property(e => e.Reserved3)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED3");

                entity.Property(e => e.Reserved4)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED4");

                entity.Property(e => e.Reserved5)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED5");

                entity.Property(e => e.SalesContractId).HasColumnName("SalesContractID");

                entity.Property(e => e.SalesOrgId).HasColumnName("SalesOrgID");

                entity.Property(e => e.SecretWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Service)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceContractId).HasColumnName("ServiceContractID");

                entity.HasOne(d => d.CardType)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.CardTypeId)
                    .HasConstraintName("FK_Card_CardType");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Card_Customer");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_Card_Program");
            });

         
            modelBuilder.Entity<CardType>(entity =>
            {
                entity.ToTable("CardType");

                entity.Property(e => e.CardTypeId)
                    .HasColumnName("CardTypeID")
                    .HasComment("PK For CardType");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IssuerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.CardTypes)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_CardType_Service");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.BillingAddress).HasMaxLength(255);

                entity.Property(e => e.CascadingStyleSheet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CompanyOrDepartment).HasMaxLength(50);

                entity.Property(e => e.ContactFirstName).HasMaxLength(30);

                entity.Property(e => e.ContactLastName).HasMaxLength(50);

                entity.Property(e => e.ContactTitle).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EntityCategoryId).HasColumnName("EntityCategoryID");

                entity.Property(e => e.Extension).HasMaxLength(30);

                entity.Property(e => e.FaxNumber).HasMaxLength(30);

                entity.Property(e => e.FedTaxId)
                    .HasMaxLength(50)
                    .HasColumnName("FedTaxID");

                entity.Property(e => e.MIdnum)
                    .HasMaxLength(6)
                    .HasColumnName("M_Idnum");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.Sponsorid).HasColumnName("sponsorid");

                entity.Property(e => e.StateOrProvince).HasMaxLength(20);

                entity.Property(e => e.TerminalId).HasColumnName("TerminalID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => new { e.CustomerId, e.CState }, "Customer76")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.CState, "Customer82")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.ActivateId, "IX_Customer_ActivateID")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CIdnum, e.CName }, "PK_C_IDNUM")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CState, e.CFname }, "missing_index_1771")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AccountNumber).HasMaxLength(24);

                entity.Property(e => e.ActivateId).HasColumnName("ActivateID");

                entity.Property(e => e.Adddate).HasColumnType("smalldatetime");

                entity.Property(e => e.Bal120).HasColumnName("BAL_120");

                entity.Property(e => e.Bal30).HasColumnName("BAL_30");

                entity.Property(e => e.Bal45).HasColumnName("BAL_45");

                entity.Property(e => e.Bal60).HasColumnName("BAL_60");

                entity.Property(e => e.Bal90).HasColumnName("BAL_90");

                entity.Property(e => e.BalCur).HasColumnName("BAL_CUR");

                entity.Property(e => e.Balance).HasColumnName("BALANCE");

                entity.Property(e => e.BeginningCardNumber).HasMaxLength(16);

                entity.Property(e => e.BusinessForm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CAba)
                    .HasMaxLength(9)
                    .HasColumnName("C_ABA");

                entity.Property(e => e.CAchid)
                    .HasMaxLength(10)
                    .HasColumnName("C_ACHID");

                entity.Property(e => e.CAddr1)
                    .HasMaxLength(64)
                    .HasColumnName("C_ADDR1");

                entity.Property(e => e.CAddr2)
                    .HasMaxLength(64)
                    .HasColumnName("C_ADDR2");

                entity.Property(e => e.CBatype)
                    .HasMaxLength(1)
                    .HasColumnName("C_BATYPE");

                entity.Property(e => e.CBnkacct)
                    .HasMaxLength(17)
                    .HasColumnName("C_BNKACCT");

                entity.Property(e => e.CBusaddr1)
                    .HasMaxLength(25)
                    .HasColumnName("C_BUSADDR1");

                entity.Property(e => e.CBusaddr2)
                    .HasMaxLength(25)
                    .HasColumnName("C_BUSADDR2");

                entity.Property(e => e.CBuscity)
                    .HasMaxLength(25)
                    .HasColumnName("C_BUSCITY");

                entity.Property(e => e.CBusstate)
                    .HasMaxLength(2)
                    .HasColumnName("C_BUSSTATE");

                entity.Property(e => e.CBuszip)
                    .HasMaxLength(10)
                    .HasColumnName("C_BUSZIP");

                entity.Property(e => e.CCity)
                    .HasMaxLength(60)
                    .HasColumnName("C_CITY");

                entity.Property(e => e.CExt)
                    .HasMaxLength(4)
                    .HasColumnName("C_EXT");

                entity.Property(e => e.CFname)
                    .HasMaxLength(25)
                    .HasColumnName("C_FNAME");

                entity.Property(e => e.CIdnum)
                    .HasMaxLength(8)
                    .HasColumnName("C_IDNUM");

                entity.Property(e => e.CInitial)
                    .HasMaxLength(1)
                    .HasColumnName("C_INITIAL");

                entity.Property(e => e.CLname)
                    .HasMaxLength(40)
                    .HasColumnName("C_LNAME");

                entity.Property(e => e.CName)
                    .HasMaxLength(100)
                    .HasColumnName("C_NAME");

                entity.Property(e => e.CNotes)
                    .HasMaxLength(100)
                    .HasColumnName("C_Notes");

                entity.Property(e => e.CPhone)
                    .HasMaxLength(13)
                    .HasColumnName("C_PHONE");

                entity.Property(e => e.CSalut)
                    .HasMaxLength(5)
                    .HasColumnName("C_SALUT");

                entity.Property(e => e.CState)
                    .HasMaxLength(2)
                    .HasColumnName("C_STATE");

                entity.Property(e => e.CTerms)
                    .HasMaxLength(10)
                    .HasColumnName("C_TERMS");

                entity.Property(e => e.CZip)
                    .HasMaxLength(10)
                    .HasColumnName("C_ZIP");

                entity.Property(e => e.CardName).HasMaxLength(24);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ClaimNum)
                    .HasMaxLength(7)
                    .HasColumnName("CLAIM_NUM");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CollBal).HasColumnName("COLL_BAL");

                entity.Property(e => e.CommunicationsDeliveryCategoryId).HasColumnName("CommunicationsDeliveryCategoryID");

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreditLimit).HasColumnType("money");

                entity.Property(e => e.CustomerServiceContact)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerServiceNo)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateMailed).HasColumnType("smalldatetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmsLiable).HasColumnName("EMS_LIABLE");

                entity.Property(e => e.EndingCardNumber).HasMaxLength(16);

                entity.Property(e => e.EntityCategoryId).HasColumnName("EntityCategoryID");

                entity.Property(e => e.EntityId).HasColumnName("EntityID");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ENTRY_DATE");

                entity.Property(e => e.FedTaxId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FedTaxID");

                entity.Property(e => e.Fieldname1)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAME1");

                entity.Property(e => e.Fieldname2)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAME2");

                entity.Property(e => e.Fieldname3)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAME3");

                entity.Property(e => e.Fieldname4)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAME4");

                entity.Property(e => e.Fieldname5)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAME5");

                entity.Property(e => e.Fieldnamecard1)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAMECard1");

                entity.Property(e => e.Fieldnamecard2)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAMECard2");

                entity.Property(e => e.Fieldnamecard3)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAMECard3");

                entity.Property(e => e.Fieldnamecard4)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAMECard4");

                entity.Property(e => e.Fieldnamecard5)
                    .HasMaxLength(20)
                    .HasColumnName("FIELDNAMECard5");

                entity.Property(e => e.IssuerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LIdnum)
                    .HasMaxLength(6)
                    .HasColumnName("L_IDNUM");

                entity.Property(e => e.MIdnum)
                    .HasMaxLength(6)
                    .HasColumnName("M_IDNUM");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.NumCards).HasColumnName("NUM_CARDS");

                entity.Property(e => e.OpId)
                    .HasMaxLength(10)
                    .HasColumnName("OP_ID");

                entity.Property(e => e.Otb1period).HasColumnName("OTB1Period");

                entity.Property(e => e.Otb2period).HasColumnName("OTB2Period");

                entity.Property(e => e.Otb3period).HasColumnName("OTB3Period");

                entity.Property(e => e.Otb4period).HasColumnName("OTB4Period");

                entity.Property(e => e.Otb5period).HasColumnName("OTB5Period");

                entity.Property(e => e.PeriodCategoryId).HasColumnName("PeriodCategoryID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PhoneFax).HasMaxLength(13);

                entity.Property(e => e.PreferredBankName).HasMaxLength(25);

                entity.Property(e => e.PrivacyLevel).HasDefaultValueSql("((330))");

                entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

                entity.Property(e => e.RemittanceId).HasColumnName("RemittanceID");

                entity.Property(e => e.Reserved1)
                    .HasMaxLength(25)
                    .HasColumnName("RESERVED1");

                entity.Property(e => e.Reserved2)
                    .HasMaxLength(25)
                    .HasColumnName("RESERVED2");

                entity.Property(e => e.Reserved3)
                    .HasMaxLength(25)
                    .HasColumnName("RESERVED3");

                entity.Property(e => e.Reserved4)
                    .HasMaxLength(25)
                    .HasColumnName("RESERVED4");

                entity.Property(e => e.Reserved5)
                    .HasMaxLength(25)
                    .HasColumnName("RESERVED5");

                entity.Property(e => e.SalesRepId).HasColumnName("SalesRepID");

                entity.Property(e => e.SentColl)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("SENT_COLL");

                entity.Property(e => e.ServiceContractId).HasColumnName("ServiceContractID");

                entity.Property(e => e.SettlementCategoryId).HasColumnName("SettlementCategoryID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");
            });

           

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ActivateSponsorId).HasColumnName("ActivateSponsorID");

                entity.Property(e => e.ActiveIndicatorId).HasColumnName("ActiveIndicatorID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BillingRate).HasColumnType("money");

                entity.Property(e => e.Birthdate).HasColumnType("smalldatetime");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedByEntityId).HasColumnName("CreatedByEntityID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateHired).HasColumnType("smalldatetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmailName).HasMaxLength(50);

                entity.Property(e => e.EmployeeEmail).HasMaxLength(500);

                entity.Property(e => e.EmployeeNumber).HasMaxLength(30);

                entity.Property(e => e.EmrgcyContactName).HasMaxLength(50);

                entity.Property(e => e.EmrgcyContactPhone).HasMaxLength(30);

                entity.Property(e => e.EntityCategoryId).HasColumnName("EntityCategoryID");

                entity.Property(e => e.Extension).HasMaxLength(30);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HomePhone).HasMaxLength(30);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(30);

                entity.Property(e => e.NationalEmplNumber).HasMaxLength(30);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.NtloginId)
                    .HasMaxLength(15)
                    .HasColumnName("NTLoginID");

                entity.Property(e => e.OfficeLocation).HasMaxLength(20);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Photograph).HasColumnType("image");

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.PrimaryPositionId).HasColumnName("PrimaryPositionID");

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.ResourceInitial)
                    .HasMaxLength(4)
                    .IsFixedLength(true);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.SocialSecurityNumber).HasMaxLength(30);

                entity.Property(e => e.SpouseName).HasMaxLength(50);

                entity.Property(e => e.StateOrProvince).HasMaxLength(20);

                entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedByEntityId).HasColumnName("UpdatedByEntityID");

                entity.Property(e => e.UserName).HasMaxLength(10);

                entity.Property(e => e.WorkPhone).HasMaxLength(30);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.HasIndex(e => new { e.LocationId, e.LocationStatus, e.ScanDataStatus }, "IDX_LocationScanDataStatus");

                entity.HasIndex(e => e.MerchantNumber, "IX_Location_Merchant_Number");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.AchbatchHeaderType).HasColumnName("ACHBatchHeaderType");

                entity.Property(e => e.AchfileCatId).HasColumnName("ACHFileCatID");

                entity.Property(e => e.Achid)
                    .HasMaxLength(11)
                    .HasColumnName("ACHID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasDefaultValueSql("((385))");

                entity.Property(e => e.Cbankname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CBANKNAME");

                entity.Property(e => e.CbterminalId).HasColumnName("CBTerminalID");

                entity.Property(e => e.CheckCollMerchantId).HasColumnName("CheckCollMerchantID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DailyHighVolume).HasMaxLength(50);

                entity.Property(e => e.DaylightSavingTime)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DealerId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DealerID");

                entity.Property(e => e.DefaultBatchCloseTypeId).HasColumnName("DefaultBatchCloseTypeID");

                entity.Property(e => e.DefaultOriginationDeviceId).HasColumnName("DefaultOriginationDeviceID");

                entity.Property(e => e.EmailAddr).HasMaxLength(50);

                entity.Property(e => e.EntityCategoryId)
                    .HasColumnName("EntityCategoryID")
                    .HasDefaultValueSql("((58))");

                entity.Property(e => e.EntityId).HasColumnName("EntityID");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRY_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileFormatId).HasColumnName("FileFormatID");

                entity.Property(e => e.InternetServiceProvider)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KioskDlparseSupport)
                    .HasColumnName("KioskDLParseSupport")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LAba)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("L_ABA");

                entity.Property(e => e.LAchid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("L_ACHID");

                entity.Property(e => e.LAddr1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("L_ADDR1");

                entity.Property(e => e.LAddr2)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("L_ADDR2");

                entity.Property(e => e.LBatype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("L_BATYPE");

                entity.Property(e => e.LBnkacct)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("L_BNKACCT");

                entity.Property(e => e.LCic)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("L_CIC");

                entity.Property(e => e.LCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("L_CITY");

                entity.Property(e => e.LExt)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("L_EXT");

                entity.Property(e => e.LFam)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("L_FAM");

                entity.Property(e => e.LFname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("L_FNAME");

                entity.Property(e => e.LIdnum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("L_IDNUM");

                entity.Property(e => e.LLname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("L_LNAME");

                entity.Property(e => e.LName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L_NAME");

                entity.Property(e => e.LPaba)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("L_PABA");

                entity.Property(e => e.LPbatype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("L_PBATYPE");

                entity.Property(e => e.LPbnkacct)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("L_PBNKACCT");

                entity.Property(e => e.LPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L_PHONE");

                entity.Property(e => e.LPhoneold)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("L_PHONEOLD");

                entity.Property(e => e.LState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("L_STATE");

                entity.Property(e => e.LZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("L_ZIP");

                entity.Property(e => e.LocationActivateId).HasColumnName("LocationActivateID");

                entity.Property(e => e.LocationCommissionAccount).HasMaxLength(25);

                entity.Property(e => e.LocationStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Location_Status");

                entity.Property(e => e.MIdnum)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("M_Idnum");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MerchantNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Merchant_Number");

                entity.Property(e => e.OpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OP_ID");

                entity.Property(e => e.Pbankname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PBANKNAME");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PropCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PumpDispenserModel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RAba)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("R_ABA");

                entity.Property(e => e.RAcct)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("R_ACCT");

                entity.Property(e => e.RBatype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("R_BATYPE");

                entity.Property(e => e.Rbankname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RBANKNAME");

                entity.Property(e => e.RejectServiceFee).HasColumnType("money");

                entity.Property(e => e.RemotePcid).HasColumnName("RemotePCID");

                entity.Property(e => e.ReserveOtb)
                    .HasColumnType("money")
                    .HasColumnName("ReserveOTB");

                entity.Property(e => e.Reserved1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED1");

                entity.Property(e => e.Reserved2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED2");

                entity.Property(e => e.Reserved3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED3");

                entity.Property(e => e.Reserved4)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED4");

                entity.Property(e => e.Reserved5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVED5");

                entity.Property(e => e.Siccode)
                    .HasMaxLength(10)
                    .HasColumnName("SICCode")
                    .IsFixedLength(true);

                entity.Property(e => e.StoreHours)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TerminalId).HasColumnName("TerminalID");

                entity.Property(e => e.TransactionLimit).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .HasColumnName("URL");

                entity.Property(e => e.WifiKey)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.WifiSecurityType).HasMaxLength(50);
            });

           

            modelBuilder.Entity<LoyaltyTransactionTEc>(entity =>
            {
                
                entity.HasKey(e => e.LoyaltyTransactionId);

                entity.ToTable("LoyaltyTransaction_T_EC");

                entity.HasIndex(e => e.CardId, "IX_LoyaltyTransaction_T_EC")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CategoryId, "IX_LoyaltyTransaction_T_EC_CategoryID")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.LocationId, "IX_LoyaltyTransaction_T_EC_LocationID")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.TransactionId, e.UpdatedDate, e.LoyaltyDetailId, e.LocationId }, "IX_LoyaltyTransaction_T_EC_TransactionID_UpdatedDate_LoyaltyDetailID_LocationID")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.TransactionId, e.LoyaltyTransactionId, e.LoyaltyDetailTerminalId, e.UpdatedDate, e.CardId, e.CategoryId, e.CardActivateId }, "_dta_index_LoyaltyTransaction_T_EC_5_338256410__K4_K1_K2_K7_K3_K5_K14_6_16_17_19")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CategoryId, e.TransactionId }, "_dta_index_LoyaltyTransaction_T_EC_5_338256410__K5_K4_10")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.CategoryId, e.TransactionId }, "_dta_index_LoyaltyTransaction_T_EC_5_338256410__K5_K4_16")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.TransactionId, e.LoyaltyDetailId, e.CategoryId, e.Discount }, "missing_index_12_11")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.TransactionId, e.CategoryId, e.LoyaltyDetailId }, "missing_index_24_23")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.TransactionId, "missing_index_44_43")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.LoyaltyDetailId, "missing_index_4965")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.CardActivateId, "missing_index_5073");

                entity.HasIndex(e => e.CategoryId, "missing_index_5085")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.UpdatedDate, "missing_index_54780")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.LoyaltyTransactionId).HasColumnName("LoyaltyTransactionID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CardActivateId).HasColumnName("CardActivateID");

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Chances)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ChangeReason)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Descriptor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Factor).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FuelGradeId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("FuelGradeID");

                entity.Property(e => e.Item)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LoyaltyCouponNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoyaltyDetailId).HasColumnName("LoyaltyDetailID");

                entity.Property(e => e.LoyaltyDetailRewardSkugroupId).HasColumnName("LoyaltyDetailRewardSKUGroupID");

                entity.Property(e => e.LoyaltyDetailTerminalId).HasColumnName("LoyaltyDetailTerminalID");

                entity.Property(e => e.LoyaltyLocationGroupId).HasColumnName("LoyaltyLocationGroupID");

                entity.Property(e => e.LoyaltyProgramId).HasColumnName("LoyaltyProgramID");

                entity.Property(e => e.LoyaltyRewardId).HasColumnName("LoyaltyRewardID");

                entity.Property(e => e.LoyaltySkugroupId).HasColumnName("LoyaltySKUGroupID");

                entity.Property(e => e.LoyaltyVendorId).HasColumnName("LoyaltyVendorID");

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PendingDiscountId).HasColumnName("PendingDiscountID");

                entity.Property(e => e.Points)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Posnum)
                    .HasMaxLength(5)
                    .HasColumnName("POSNum")
                    .IsFixedLength(true);

                entity.Property(e => e.PostransactionId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("POSTransactionID");

                entity.Property(e => e.PromoText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.RedemptionAmount).HasColumnType("money");

                entity.Property(e => e.RedemptionLoyaltyTransactionId).HasColumnName("RedemptionLoyaltyTransactionID");

                entity.Property(e => e.RequiredPoints).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.ResponseLoyaltySequenceId).HasColumnName("ResponseLoyaltySequenceID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Upc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPC");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.LoyaltyTransactionTEcs)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("FK_LoyaltyTransaction_T_EC_Card");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("Processor");

                entity.Property(e => e.ProcessorId).HasColumnName("ProcessorID");

                entity.Property(e => e.Address)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Contact)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EntityCategoryId).HasColumnName("EntityCategoryID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PArc).HasColumnName("P_ARC");

                entity.Property(e => e.PChrgfax)
                    .HasMaxLength(14)
                    .HasColumnName("P_CHRGFAX");

                entity.Property(e => e.PChrgphon)
                    .HasMaxLength(14)
                    .HasColumnName("P_CHRGPHON");

                entity.Property(e => e.PEcard).HasColumnName("P_ECARD");

                entity.Property(e => e.PEcheck).HasColumnName("P_ECHECK");

                entity.Property(e => e.PHelpfax)
                    .HasMaxLength(14)
                    .HasColumnName("P_HELPFAX");

                entity.Property(e => e.PHelpphon)
                    .HasMaxLength(14)
                    .HasColumnName("P_HELPPHON");

                entity.Property(e => e.PServfax)
                    .HasMaxLength(14)
                    .HasColumnName("P_SERVFAX");

                entity.Property(e => e.PServphon)
                    .HasMaxLength(14)
                    .HasColumnName("P_SERVPHON");

                entity.Property(e => e.PSuppfax)
                    .HasMaxLength(14)
                    .HasColumnName("P_SUPPFAX");

                entity.Property(e => e.PSupphon)
                    .HasMaxLength(14)
                    .HasColumnName("P_SUPPHON");

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProcessorName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SalesContact)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SalesContactPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("URL")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("Program");

                entity.HasIndex(e => new { e.ProgramId, e.CardId }, "IX_ProgramIDCardID");

                entity.HasIndex(e => e.ServiceId, "IX_Program_ServiceID");

                entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

                entity.Property(e => e.AchcategoryId).HasColumnName("ACHCategoryID");

                entity.Property(e => e.ActivityAccountTerminalId).HasColumnName("ActivityAccountTerminalID");

                entity.Property(e => e.AdminRepairDaysMax).HasDefaultValueSql("((7))");

                entity.Property(e => e.Arfid).HasColumnName("ARFID");

                entity.Property(e => e.AstatusAuthBehaviorCategoryId)
                    .HasColumnName("AStatusAuthBehaviorCategoryID")
                    .HasDefaultValueSql("((1128))");

                entity.Property(e => e.AuthExpiration).HasColumnName("Auth_Expiration");

                entity.Property(e => e.BackOfficeSupplierId).HasColumnName("BackOfficeSupplierID");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.BarCodeCategoryId).HasColumnName("BarCodeCategoryID");

                entity.Property(e => e.Bin)
                    .HasMaxLength(10)
                    .HasColumnName("BIN");

                entity.Property(e => e.CardActivationCategoryId).HasColumnName("CardActivationCategoryID");

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.CardToCardMax).HasColumnType("money");

                entity.Property(e => e.CardToCardMin).HasColumnType("money");

                entity.Property(e => e.CascadingStyleSheet)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ClientCategoryId).HasColumnName("ClientCategoryID");

                entity.Property(e => e.CollectionTerminalId).HasColumnName("CollectionTerminalID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreditOffSetTerminalId).HasColumnName("CreditOffSetTerminalID");

                entity.Property(e => e.DeclineAdminFooter1).HasColumnType("text");

                entity.Property(e => e.DeclineAdminFooter2).HasColumnType("text");

                entity.Property(e => e.DeclineAdminHeader1).HasColumnType("text");

                entity.Property(e => e.DeclineAdminHeader2).HasColumnType("text");

                entity.Property(e => e.DeclineFooter1).HasColumnType("text");

                entity.Property(e => e.DeclineFooter2).HasColumnType("text");

                entity.Property(e => e.DeclineHeader1).HasColumnType("text");

                entity.Property(e => e.DeclineHeader2).HasColumnType("text");

                entity.Property(e => e.DeclinePreFooter1).HasColumnType("text");

                entity.Property(e => e.DeclinePreFooter2).HasColumnType("text");

                entity.Property(e => e.DeclinePreHeader1).HasColumnType("text");

                entity.Property(e => e.DeclinePreHeader2).HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnrollmentCategoryId).HasColumnName("EnrollmentCategoryID");

                entity.Property(e => e.EnrollmentMonitorPeriod).HasDefaultValueSql("((6))");

                entity.Property(e => e.EntityCategoryId).HasColumnName("EntityCategoryID");

                entity.Property(e => e.EntityId).HasColumnName("EntityID");

                entity.Property(e => e.FontLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FundingAccountCardId).HasColumnName("FundingAccountCardID");

                entity.Property(e => e.HelpDeskPhoneNumber).HasMaxLength(14);

                entity.Property(e => e.HelpdeskId).HasColumnName("HelpdeskID");

                entity.Property(e => e.HoldDate).HasColumnName("Hold_Date");

                entity.Property(e => e.HoldTil).HasColumnName("Hold_Til");

                entity.Property(e => e.InitialCreditLimit).HasColumnType("money");

                entity.Property(e => e.InstitutionNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IssuanceCategoryId).HasColumnName("IssuanceCategoryID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.LostAndStolenLocationId).HasColumnName("LostAndStolenLocationID");

                entity.Property(e => e.LotSize).HasMaxLength(6);

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MobileSupplierId)
                    .HasColumnName("MobileSupplierID")
                    .HasDefaultValueSql("((163))");

                entity.Property(e => e.NcnenrollValidate).HasColumnName("NCNEnrollValidate");

                entity.Property(e => e.OperatorPhone)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Otbinitial)
                    .HasColumnType("money")
                    .HasColumnName("OTBInitial");

                entity.Property(e => e.OtbmanagementEnable).HasColumnName("OTBManagementEnable");

                entity.Property(e => e.Otbmax)
                    .HasColumnType("money")
                    .HasColumnName("OTBMax");

                entity.Property(e => e.Otbmin)
                    .HasColumnType("money")
                    .HasColumnName("OTBMin");

                entity.Property(e => e.OtbpreAuthMaximum).HasColumnName("OTBPreAuthMaximum");

                entity.Property(e => e.ParentProgramId).HasColumnName("ParentProgramID");

                entity.Property(e => e.Prenote).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrivacyPolicyDocumentsId).HasColumnName("PrivacyPolicyDocumentsID");

                entity.Property(e => e.ProcessorId).HasColumnName("ProcessorID");

                entity.Property(e => e.ProcessorPrincipalBankNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Processor_Principal_Bank_Number");

                entity.Property(e => e.ProcessorSystemNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Processor_System_Number");

                entity.Property(e => e.ProgramActivateId).HasColumnName("ProgramActivateID");

                entity.Property(e => e.ProgramCategoryId).HasColumnName("ProgramCategoryID");

                entity.Property(e => e.ProgramInstitutionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramName).HasMaxLength(75);

                entity.Property(e => e.ProgramProcessorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ProgramProcessorID")
                    .IsFixedLength(true);

                entity.Property(e => e.PwdCategoryId).HasColumnName("PwdCategoryID");

                entity.Property(e => e.QstatusAuthBehaviorCategoryId)
                    .HasColumnName("QStatusAuthBehaviorCategoryID")
                    .HasDefaultValueSql("((1130))");

                entity.Property(e => e.ReOrderLevel).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ReserveTerminalId).HasColumnName("ReserveTerminalID");

                entity.Property(e => e.SalesOrgId).HasColumnName("SalesOrgID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ShrinkageFactor)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SponsorId).HasColumnName("SponsorID");

                entity.Property(e => e.StatementName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.TapagingLimit).HasColumnName("TAPAgingLimit");

                entity.Property(e => e.TerminalId).HasColumnName("TerminalID");

                entity.Property(e => e.TermsConditionsDocId).HasColumnName("TermsConditionsDocID");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TransactionMaximum).HasColumnType("money");

                entity.Property(e => e.TransactionMinimum).HasColumnType("money");

                entity.Property(e => e.TxnMonitorPeriod).HasDefaultValueSql("((6))");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.UserDefineLabel1).HasMaxLength(20);

                entity.Property(e => e.UserDefineLabel2).HasMaxLength(20);

                entity.Property(e => e.UserDefineLabel3).HasMaxLength(20);

                entity.Property(e => e.UserDefineLabel4).HasMaxLength(20);

                entity.Property(e => e.UserDefineLabel5).HasMaxLength(20);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Program_Bank");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Program_Company");

                entity.HasOne(d => d.Processor)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.ProcessorId)
                    .HasConstraintName("FK_Program_Processor");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_Program_Service");

                entity.HasOne(d => d.Sponsor)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.SponsorId)
                    .HasConstraintName("FK_Program_Sponsor");
            });

           

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ServiceDescription).HasColumnType("ntext");

                entity.Property(e => e.ServiceName).HasMaxLength(50);

                entity.Property(e => e.SettlementCategoryId).HasColumnName("SettlementCategoryID");

                entity.Property(e => e.Urladdress)
                    .HasColumnType("ntext")
                    .HasColumnName("URLAddress");
            });
            modelBuilder.Entity<Tapbatch>(entity =>
            {
                entity.ToTable("TAPBatch");

                entity.HasIndex(e => e.CutoffDate, "IX_TAPBatch_CutOffDate")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.TerminalId, e.CaptureId, e.ProcessDate }, "IX_TAPBatch_ProcessDate")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.TerminalId, "IX_TAPBatch_TerminalID")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.ReqCode, "missing_index_1012")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.TapbatchId).HasColumnName("TAPBatchID");

                entity.Property(e => e.BatchAmount).HasColumnType("money");

                entity.Property(e => e.BatchCloseCategoryId).HasColumnName("BatchCloseCategoryID");

                entity.Property(e => e.BatchType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaptureId).HasColumnName("CaptureID");

                entity.Property(e => e.CutoffDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.ReqCode)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TerminalId).HasColumnName("TerminalID");

                entity.HasOne(d => d.Terminal)
                    .WithMany(p => p.Tapbatches)
                    .HasForeignKey(d => d.TerminalId)
                    .HasConstraintName("FK_TAPBatch_Terminal_4");
            });

            modelBuilder.Entity<Terminal>(entity =>
            {
                entity.HasKey(e => e.Terminal30Id);

                entity.ToTable("Terminal");

                entity.HasIndex(e => e.TId, "IX_Terminal")
                    .IsUnique()
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.CategoryId, "IX_Terminal_CategoryID");

                entity.HasIndex(e => new { e.CategoryId, e.MerchantId, e.Terminal30Id }, "IX_Terminal_CategoryID_MerchantID_Terminal30ID");

                entity.HasIndex(e => e.Terminal30Id, "IX_Terminal_Terminal30ID_Include")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.ProcessorId, e.ProcessorTId }, "missing_index_801")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.ProcessorTId, "missing_index_917")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Terminal30Id).HasColumnName("Terminal30ID");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.BatchCloseTypeId).HasColumnName("BatchCloseTypeID");

                entity.Property(e => e.CascadingStyleSheet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CloseTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedByEntityId).HasColumnName("CreatedByEntityID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.NetworkId).HasColumnName("NetworkID");

                entity.Property(e => e.NetworkTid)
                    .HasMaxLength(50)
                    .HasColumnName("NetworkTID");

                entity.Property(e => e.OriginationDeviceId).HasColumnName("OriginationDeviceID");

                entity.Property(e => e.ProcessorId).HasColumnName("ProcessorID");

                entity.Property(e => e.ProcessorTId)
                    .HasMaxLength(50)
                    .HasColumnName("Processor_T_ID");

                entity.Property(e => e.SalesRepId).HasColumnName("SalesRepID");

                entity.Property(e => e.SeccCategoryId).HasColumnName("SECC_CategoryID");

                entity.Property(e => e.ServiceContractId).HasColumnName("ServiceContractID");

                entity.Property(e => e.ShortDescrip).HasMaxLength(8);

                entity.Property(e => e.SoftwareVersion)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SubServiceId).HasColumnName("SubServiceID");

                entity.Property(e => e.TCic)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T_CIC");

                entity.Property(e => e.TId)
                    .HasMaxLength(20)
                    .HasColumnName("T_ID");

                entity.Property(e => e.TSerial)
                    .HasMaxLength(50)
                    .HasColumnName("T_SERIAL");

                entity.Property(e => e.TeamViewerId).HasColumnName("TeamViewerID");

                entity.Property(e => e.TermDescrip)
                    .HasMaxLength(50)
                    .HasColumnName("Term_Descrip");

                entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedByEntityId).HasColumnName("UpdatedByEntityID");
            });


            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.ToTable("Sponsor");

                entity.Property(e => e.SponsorId).HasColumnName("SponsorID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltIdpriorityCategoryId).HasColumnName("AltIDPriorityCategoryID");

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.CascadingStyleSheet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContractBeginDate).HasColumnType("datetime");

                entity.Property(e => e.ContractEndDate).HasColumnType("datetime");

                entity.Property(e => e.ContractNotifyDate).HasColumnType("datetime");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedByEntityId).HasColumnName("CreatedByEntityID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DefaultLoyaltyVendorId).HasColumnName("DefaultLoyaltyVendorID");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EntityCategoryId)
                    .HasColumnName("EntityCategoryID")
                    .HasDefaultValueSql("((65))");

                entity.Property(e => e.EntityId).HasColumnName("EntityID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FedTaxId)
                    .HasMaxLength(50)
                    .HasColumnName("FedTaxID");

                entity.Property(e => e.FieldName1).HasMaxLength(50);

                entity.Property(e => e.FieldName2).HasMaxLength(50);

                entity.Property(e => e.LostStolenLocationId).HasColumnName("LostStolenLocationID");

                entity.Property(e => e.LoyaltyvendorId).HasColumnName("loyaltyvendorID");

                entity.Property(e => e.MaxSkudescriptorLength).HasColumnName("MaxSKUDescriptorLength");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MobileApplicationId).HasColumnName("MobileApplicationID");

                entity.Property(e => e.PapclientNumber)
                    .HasMaxLength(25)
                    .HasColumnName("PAPClientNumber");

                entity.Property(e => e.PdsclientNumber)
                    .HasMaxLength(25)
                    .HasColumnName("PDSClientNumber");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceBookUpcsHaveCheckDigit).HasColumnName("PriceBookUPCsHaveCheckDigit");

                entity.Property(e => e.PriceBookUpcsHaveLeadingZeros).HasColumnName("PriceBookUPCsHaveLeadingZeros");

                entity.Property(e => e.PrincipalBankNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PRINCIPAL_BANK_NUMBER");

                entity.Property(e => e.ServiceContractId).HasColumnName("ServiceContractID");

                entity.Property(e => e.SkumatchingCategoryId).HasColumnName("SKUMatchingCategoryID");

                entity.Property(e => e.SponsorAchext)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SponsorACHExt")
                    .HasDefaultValueSql("('ach')");

                entity.Property(e => e.SponsorActivateId).HasColumnName("SponsorActivateID");

                entity.Property(e => e.SponsorEmployeeId).HasColumnName("SponsorEmployeeID");

                entity.Property(e => e.SponsorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StandardEntryClassCode)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.SystemNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SYSTEM_NUMBER");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedByEntityId).HasColumnName("UpdatedByEntityID");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.HasKey(e => e.FeedBackId)
                    .HasName("PK_FeedBack_T_EC_1");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.Name).IsFixedLength(true);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Question).IsUnicode(false);
            });

            modelBuilder.Entity<LocationProfile>(entity =>
            {
                entity.Property(e => e.CardsAccpeted).IsFixedLength(true);

                entity.Property(e => e.Commments).IsUnicode(false);

                entity.Property(e => e.CreditCardAcquirer).IsUnicode(false);

                entity.Property(e => e.DealerId).IsFixedLength(true);

                entity.Property(e => e.FuelBrand).IsUnicode(false);

                entity.Property(e => e.InternetServiceProvider).IsUnicode(false);

                entity.Property(e => e.LayOut).IsFixedLength(true);

                entity.Property(e => e.MerchantNumber)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OpHours).IsFixedLength(true);

                entity.Property(e => e.OriginationDeviceSerial).IsFixedLength(true);

                entity.Property(e => e.OtherLoyaltyService).IsFixedLength(true);

                entity.Property(e => e.PosapplicationVersion).IsUnicode(false);

                entity.Property(e => e.Posappplication).IsUnicode(false);

                entity.Property(e => e.PosmaintSupport).IsFixedLength(true);

                entity.Property(e => e.PosmaintSupportPhone).IsFixedLength(true);

                entity.Property(e => e.PosproductEntryMethods).IsFixedLength(true);

                entity.Property(e => e.Posrouter).IsFixedLength(true);

                entity.Property(e => e.PosrouterBrand).IsFixedLength(true);

                entity.Property(e => e.PumpDispenserModel).IsUnicode(false);

                entity.Property(e => e.PumpTopperSize).IsFixedLength(true);

                entity.Property(e => e.RackBarrelHeight).IsFixedLength(true);

                entity.Property(e => e.RemoteAccessId).IsFixedLength(true);

                entity.Property(e => e.SurgeProtection).IsUnicode(false);

                entity.Property(e => e.WifiKey).IsFixedLength(true);
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.Property(e => e.EntityCategoryId).HasDefaultValueSql("((57))");

                entity.Property(e => e.GroupRejects).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupSettlement).HasDefaultValueSql("((-1))");

                entity.Property(e => e.HDays).HasDefaultValueSql("((1))");

                entity.Property(e => e.PbankAddress)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PbankState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PbankZip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrivacyLevel).HasDefaultValueSql("((330))");
            });

            modelBuilder.Entity<MerchantProfile>(entity =>
            {
                entity.Property(e => e.AccountNumber).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<MerchantMVC.ViewModels.CallTrackingViewModel> CallTrackingViewModel { get; set; }

        public DbSet<MerchantMVC.ViewModels.LoyaltyTranViewModel> LoyaltyTranViewModel { get; set; }

        public DbSet<MerchantMVC.ViewModels.MerchantProfileViewModel> MerchantProfileViewModel { get; set; }

        public DbSet<MerchantMVC.ViewModels.MerchantViewModel> MerchantViewModel { get; set; }

        public DbSet<MerchantMVC.ViewModels.EditLocationViewModel> EditLocationViewModel { get; set; }

        public DbSet<MerchantMVC.ViewModels.TerminalViewModel> TerminalViewModel { get; set; }

        public DbSet<MerchantMVC.ViewModels.FeedBackViewModel> FeedBackViewModel { get; set; }
    }
}
