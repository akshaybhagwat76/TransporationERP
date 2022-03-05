using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using TransportationERP.DAL.Model;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class MMS_WebContext : DbContext
    {
        private readonly IConfiguration m_config;
        public MMS_WebContext()
        {
        }

        public MMS_WebContext(DbContextOptions<MMS_WebContext> options, IConfiguration config)
            : base(options)
        {
            m_config = config;

        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<TransactionHeader> TransactionHeaders { get; set; }
        public virtual DbSet<TransactionOtherPicture> TransactionOtherPictures { get; set; }
        public virtual DbSet<TransactionReceivedPaperword> TransactionReceivedPaperwords { get; set; }
        public virtual DbSet<TransactionScalePicture> TransactionScalePictures { get; set; }
        public virtual DbSet<TransportationCommodity> TransportationCommodities { get; set; }
        public virtual DbSet<TransportationLocation> TransportationLocations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<TransectionSetting> TransectionSetting { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccountId)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.IncludeTransportation).HasColumnName("Include_Transportation");

                entity.Property(e => e.Representative)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transaction_Detail");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.DetailId).HasColumnName("DetailID");

                entity.Property(e => e.TicketNumber)
                    .HasMaxLength(8)
                    .IsFixedLength(true);

                entity.Property(e => e.TotalCost).HasColumnType("money");

                entity.Property(e => e.UnitCost).HasColumnType("money");
            });

            modelBuilder.Entity<TransactionHeader>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transaction_Header");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.CarrierTicket)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(11)
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentReceiptUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PaymentReceiptURL");

                entity.Property(e => e.PaymentTerms)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierTicket)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TicketDate).HasColumnType("date");

                entity.Property(e => e.TicketNumber)
                    .HasMaxLength(8)
                    .IsFixedLength(true);

                entity.Property(e => e.TruckDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransactionOtherPicture>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transaction_OtherPictures");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.FullResUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FullRes_URL");

                entity.Property(e => e.PictureId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PictureID");

                entity.Property(e => e.ThumbnailUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Thumbnail_URL");

                entity.Property(e => e.TicketNumber)
                    .HasMaxLength(8)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TransactionReceivedPaperword>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transaction_ReceivedPaperword");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.FullResUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FullRes_URL");

                entity.Property(e => e.PictureId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PictureID");

                entity.Property(e => e.ThumbnailUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Thumbnail_URL");

                entity.Property(e => e.TicketNumber)
                    .HasMaxLength(8)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TransactionScalePicture>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transaction_ScalePictures");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.FullResUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FullRes_URL");

                entity.Property(e => e.PictureId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PictureID");

                entity.Property(e => e.ThumbnailUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Thumbnail_URL");

                entity.Property(e => e.TicketNumber)
                    .HasMaxLength(8)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TransportationCommodity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transportation_Commodities");

                entity.Property(e => e.AccountID)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.CommodityID).HasColumnName("CommodityID");

                entity.Property(e => e.Commodity_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Commodity_Name");

                entity.Property(e => e.LocationID).HasColumnName("LocationID");
            });

            modelBuilder.Entity<TransportationLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transportation_Locations");

                entity.Property(e => e.AccountID)
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.LocationID).HasColumnName("LocationID");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.AccountDisabled).HasColumnName("Account_Disabled");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordVersion).HasColumnName("Password_Version");

                entity.Property(e => e.Salt).HasMaxLength(36);
            });

            modelBuilder.Entity<UserHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_History");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("IP")
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
