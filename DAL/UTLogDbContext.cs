using System;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppCore.DAL
{
    public partial class UTLogDbContext : DbContext
    {
        public UTLogDbContext()
        {
        }

        public UTLogDbContext(DbContextOptions<UTLogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Poheader> Poheader { get; set; }
        public virtual DbSet<Poitem> Poitem { get; set; }
        public virtual DbSet<PoitemDetail> PoitemDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:utsqlserver.database.windows.net,1433;Initial Catalog=UTLogDb;Persist Security Info=False;User ID=unitedtractorapp;Password=P@ssw0rd12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .ValueGeneratedNever();

                entity.Property(e => e.Action).IsRequired();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Poheader>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("POHeader");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("AK_POHeader")
                    .IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Eta)
                    .HasColumnName("ETA")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ponumber)
                    .IsRequired()
                    .HasColumnName("PONumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Poitem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);

                entity.ToTable("POItem");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.ItemStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PartDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Poitem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POItem_POHeader");
            });

            modelBuilder.Entity<PoitemDetail>(entity =>
            {
                entity.HasKey(e => e.OrderItemDetailId);

                entity.ToTable("POItemDetail");

                entity.Property(e => e.OrderItemDetailId).HasColumnName("OrderItemDetailID");

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Etadate)
                    .HasColumnName("ETADate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemDetailStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.PoitemDetail)
                    .HasForeignKey(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POItemDetail_POItem");
            });
        }
    }
}
