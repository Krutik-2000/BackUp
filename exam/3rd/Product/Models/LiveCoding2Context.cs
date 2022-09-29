using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Product.Models
{
    public partial class LiveCoding2Context : DbContext
    {
        public LiveCoding2Context()
        {
        }

        public LiveCoding2Context(DbContextOptions<LiveCoding2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AllDatum> AllData { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC0765\\MSSQL2019;Database=LiveCoding2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllDatum>(entity =>
            {
                entity.HasKey(e => e.DataId)
                    .HasName("PK__AllData__923E36A51AAF766A");

                entity.Property(e => e.DataId).HasColumnName("dataId");

                entity.Property(e => e.Icon).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSku).HasColumnName("ProductSKU");

                entity.Property(e => e.ReferenceNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("referenceNumber");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 3)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AllData)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__AllData__Categor__6477ECF3");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Icon)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSku).HasColumnName("ProductSKU");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 3)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__778AC167");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
