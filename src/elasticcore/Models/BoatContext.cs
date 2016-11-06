using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace elasticcore.Models
{
    public partial class BoatContext : DbContext
    {
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BoatCategories> BoatCategories { get; set; }
        public virtual DbSet<BoatImages> BoatImages { get; set; }
        public virtual DbSet<BoatViews> BoatViews { get; set; }
        public virtual DbSet<Boats> Boats { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ContactEnquiries> ContactEnquiries { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Enquiries> Enquiries { get; set; }
        public virtual DbSet<EnquiryReadStatuses> EnquiryReadStatuses { get; set; }
        public virtual DbSet<LogEntries> LogEntries { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<NewsItems> NewsItems { get; set; }
        public virtual DbSet<Nlog> Nlog { get; set; }
        public virtual DbSet<Pdfs> Pdfs { get; set; }
        public virtual DbSet<PriceComments> PriceComments { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<SaleEnquiries> SaleEnquiries { get; set; }
        public virtual DbSet<SaleEnquiryReadStatuses> SaleEnquiryReadStatuses { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<TaskLogs> TaskLogs { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }
        public virtual DbSet<WebpagesMembership> WebpagesMembership { get; set; }
        public virtual DbSet<WebpagesOauthMembership> WebpagesOauthMembership { get; set; }
        public virtual DbSet<WebpagesRoles> WebpagesRoles { get; set; }
        public virtual DbSet<WebpagesUsersInRoles> WebpagesUsersInRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=.\;Database=SQL2012_938573_gbrbs;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BoatCategories>(entity =>
            {
                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.BoatCategories)
                    .HasForeignKey(d => d.BoatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BoatCategories_Boats");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BoatCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BoatCategories_Categories");
            });

            modelBuilder.Entity<BoatImages>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Deleted).HasDefaultValueSql("0");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.BoatImages)
                    .HasForeignKey(d => d.BoatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BoatImages_Boats");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BoatImagesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BoatImages_CreatedUsers");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.BoatImagesUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BoatImages_UpdatedUsers");
            });

            modelBuilder.Entity<BoatViews>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.BoatViews)
                    .HasForeignKey(d => d.BoatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BoatViews_Boats");
            });

            modelBuilder.Entity<Boats>(entity =>
            {
                entity.Property(e => e.Accommodation).HasColumnType("varchar(800)");

                entity.Property(e => e.Bdid).HasColumnName("BDId");

                entity.Property(e => e.BdstockNumber)
                    .HasColumnName("BDStockNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Beam).HasColumnType("varchar(50)");

                entity.Property(e => e.Builder).HasMaxLength(100);

                entity.Property(e => e.Covers).HasColumnType("varchar(1000)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeckGear).HasColumnType("varchar(800)");

                entity.Property(e => e.DecksMaterial).HasColumnType("varchar(100)");

                entity.Property(e => e.Deleted).HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Designer).HasMaxLength(100);

                entity.Property(e => e.Dinghy).HasColumnType("varchar(1000)");

                entity.Property(e => e.Draft).HasColumnType("varchar(60)");

                entity.Property(e => e.Electrics).HasColumnType("varchar(1500)");

                entity.Property(e => e.Electronics).HasColumnType("varchar(800)");

                entity.Property(e => e.Engine).HasColumnType("varchar(1200)");

                entity.Property(e => e.EngineHours).HasColumnType("varchar(80)");

                entity.Property(e => e.EngineRoom).HasColumnType("varchar(800)");

                entity.Property(e => e.Facebook).HasDefaultValueSql("0");

                entity.Property(e => e.Fuel).HasColumnType("varchar(80)");

                entity.Property(e => e.Galley).HasColumnType("varchar(1500)");

                entity.Property(e => e.GenSet).HasColumnType("varchar(160)");

                entity.Property(e => e.GroundTackle).HasColumnType("varchar(800)");

                entity.Property(e => e.HullMaterial)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Keel).HasColumnType("varchar(100)");

                entity.Property(e => e.Length)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Location).HasColumnType("varchar(60)");

                entity.Property(e => e.MakeModel)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Outboard).HasColumnType("varchar(1000)");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.Property(e => e.Ref)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Refrigeration).HasColumnType("varchar(800)");

                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Remarks).HasColumnType("varchar(800)");

                entity.Property(e => e.Rigging).HasColumnType("varchar(800)");

                entity.Property(e => e.SafetyGear).HasColumnType("varchar(800)");

                entity.Property(e => e.SailInventory).HasColumnType("varchar(800)");

                entity.Property(e => e.Shower).HasColumnType("varchar(100)");

                entity.Property(e => e.Survey).HasColumnType("varchar(800)");

                entity.Property(e => e.Toilet).HasColumnType("varchar(1000)");

                entity.Property(e => e.Tweeted).HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VesselName).HasColumnType("varchar(150)");

                entity.Property(e => e.Visible).HasDefaultValueSql("1");

                entity.Property(e => e.Water).HasColumnType("varchar(80)");

                entity.Property(e => e.Weight).HasColumnType("varchar(50)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BoatsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boats_CreatedUsers");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Boats)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_Boats_Currencies");

                entity.HasOne(d => d.PriceComment)
                    .WithMany(p => p.Boats)
                    .HasForeignKey(d => d.PriceCommentId)
                    .HasConstraintName("FK_Boats_PriceComments");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Boats)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boats_Regions");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Boats)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boats_Statuses");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Boats)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boats_Units");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.BoatsUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Boats_UpdatedUsers");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_Categories");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.NewType).HasDefaultValueSql("0");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("0");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'aaa'");
            });

            modelBuilder.Entity<ContactEnquiries>(entity =>
            {
                entity.HasKey(e => e.ContactEnquiryId)
                    .HasName("PK_ContactEnquiries");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Deleted).HasDefaultValueSql("0");

                entity.Property(e => e.Email).HasColumnType("varchar(100)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("varchar(3000)");

                entity.Property(e => e.Mobile).HasColumnType("varchar(15)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Phone).HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("PK_Currencies");

                entity.Property(e => e.Description).HasColumnType("varchar(100)");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasColumnType("varchar(5)");
            });

            modelBuilder.Entity<Enquiries>(entity =>
            {
                entity.Property(e => e.DateSubmitted).HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnType("varchar(3000)");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Location).HasColumnType("varchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Phone).HasColumnType("varchar(15)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.Enquiries)
                    .HasForeignKey(d => d.BoatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Enquiries_Boats");
            });

            modelBuilder.Entity<EnquiryReadStatuses>(entity =>
            {
                entity.HasKey(e => e.EnquiryReadStatusId)
                    .HasName("PK_EnquiryReadStatuses");

                entity.Property(e => e.ReadDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Enquiry)
                    .WithMany(p => p.EnquiryReadStatuses)
                    .HasForeignKey(d => d.EnquiryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EnquiryReadStatuses_Enquiries");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EnquiryReadStatuses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EnquiryReadStatuses_Users");
            });

            modelBuilder.Entity<LogEntries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Callsite).HasMaxLength(300);

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Logged).HasColumnType("datetime");

                entity.Property(e => e.Logger).HasMaxLength(300);

                entity.Property(e => e.MachineName).HasMaxLength(200);

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Port).HasMaxLength(100);

                entity.Property(e => e.RemoteAddress).HasMaxLength(100);

                entity.Property(e => e.ServerAddress).HasMaxLength(100);

                entity.Property(e => e.ServerName).HasMaxLength(200);

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Url).HasMaxLength(2000);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_Logs");

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LogText)
                    .IsRequired()
                    .HasColumnType("varchar(5000)");

                entity.Property(e => e.LogType).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<NewsItems>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Deleted).HasDefaultValueSql("0");

                entity.Property(e => e.Facebook).HasDefaultValueSql("0");

                entity.Property(e => e.ImageFilename).HasMaxLength(150);

                entity.Property(e => e.NewsText).IsRequired();

                entity.Property(e => e.Publish).HasDefaultValueSql("1");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Twitter).HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.NewsItemsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NewsItems_CreatedUsers");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.NewsItemsUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NewsItems_UpdatedUsers");
            });

            modelBuilder.Entity<Nlog>(entity =>
            {
                entity.ToTable("NLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Callsite).HasMaxLength(300);

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Logged).HasColumnType("datetime");

                entity.Property(e => e.Logger).HasMaxLength(300);

                entity.Property(e => e.MachineName).HasMaxLength(200);

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Port).HasMaxLength(100);

                entity.Property(e => e.RemoteAddress).HasMaxLength(100);

                entity.Property(e => e.ServerAddress).HasMaxLength(100);

                entity.Property(e => e.ServerName).HasMaxLength(200);

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Url).HasMaxLength(2000);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<Pdfs>(entity =>
            {
                entity.HasKey(e => e.PdfId)
                    .HasName("PK_Pdfs");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Deleted).HasDefaultValueSql("0");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.Pdfs)
                    .HasForeignKey(d => d.BoatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Pdfs_Boats");
            });

            modelBuilder.Entity<PriceComments>(entity =>
            {
                entity.HasKey(e => e.PriceCommentId)
                    .HasName("PK_PriceComments");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("PK_Regions");

                entity.Property(e => e.Abbr)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SaleEnquiries>(entity =>
            {
                entity.HasKey(e => e.SaleEnquiryId)
                    .HasName("PK_SaleEnquiries");

                entity.Property(e => e.BoatType)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.CommercialSurvey).HasDefaultValueSql("1");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Details).HasColumnType("varchar(3000)");

                entity.Property(e => e.Draft).HasColumnType("decimal");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.Engine).HasColumnType("varchar(1000)");

                entity.Property(e => e.HullType)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Length).HasColumnType("decimal");

                entity.Property(e => e.Location).HasColumnType("varchar(300)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Width).HasColumnType("decimal");

                entity.HasOne(d => d.CustomerRegion)
                    .WithMany(p => p.SaleEnquiriesCustomerRegion)
                    .HasForeignKey(d => d.CustomerRegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SaleEnquiries_Regions");

                entity.HasOne(d => d.VesselRegion)
                    .WithMany(p => p.SaleEnquiriesVesselRegion)
                    .HasForeignKey(d => d.VesselRegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SaleEnquiries_Regions1");
            });

            modelBuilder.Entity<SaleEnquiryReadStatuses>(entity =>
            {
                entity.HasKey(e => e.SaleEnquiryReadStatusId)
                    .HasName("PK_SaleEnquiryReadStatuses");

                entity.Property(e => e.ReadDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.SaleEnquiry)
                    .WithMany(p => p.SaleEnquiryReadStatuses)
                    .HasForeignKey(d => d.SaleEnquiryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SaleEnquiryReadStatuses_SaleEnquiries");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SaleEnquiryReadStatuses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SaleEnquiryReadStatuses_Users");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_Statuses");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TaskLogs>(entity =>
            {
                entity.Property(e => e.Message).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RunTime).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK_Units");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Users");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.HasKey(e => e.VideoId)
                    .HasName("PK_Videos");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.BoatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Videos_Boats");
            });

            modelBuilder.Entity<WebpagesMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__webpages__1788CC4C0FB65D00");

                entity.ToTable("webpages_Membership");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.ConfirmationToken).HasMaxLength(128);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("0");

                entity.Property(e => e.LastPasswordFailureDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordFailuresSinceLastSuccess).HasDefaultValueSql("0");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationToken).HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationTokenExpirationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WebpagesOauthMembership>(entity =>
            {
                entity.HasKey(e => new { e.Provider, e.ProviderUserId })
                    .HasName("PK__webpages__F53FC0EDE9151FEB");

                entity.ToTable("webpages_OAuthMembership");

                entity.Property(e => e.Provider).HasMaxLength(30);

                entity.Property(e => e.ProviderUserId).HasMaxLength(100);
            });

            modelBuilder.Entity<WebpagesRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__webpages__8AFACE1A2278003A");

                entity.ToTable("webpages_Roles");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ__webpages__8A2B61606E81679F")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<WebpagesUsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__webpages__AF2760ADF2135D80");

                entity.ToTable("webpages_UsersInRoles");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.WebpagesUsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WebpagesUsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_UserId");
            });
        }
    }
}