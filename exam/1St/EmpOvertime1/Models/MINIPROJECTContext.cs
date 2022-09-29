using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmpOvertime1.Models
{
    public partial class MINIPROJECTContext : DbContext
    {
        public MINIPROJECTContext()
        {
        }

        public MINIPROJECTContext(DbContextOptions<MINIPROJECTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationObjectType> ApplicationObjectTypes { get; set; }
        public virtual DbSet<ObjectType> ObjectTypes { get; set; }
        public virtual DbSet<Overtime> Overtimes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VOvertime> VOvertimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC0765\\MSSQL2019;Database=MINIPROJECT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationObjectType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK__Applicat__9A619291A7A769B8");

                entity.ToTable("ApplicationObjectType");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<ObjectType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__ObjectTy__516F03B5D583A40B");

                entity.ToTable("ObjectType");

                entity.Property(e => e.TypeValue)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.ObjectTypes)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("FK__ObjectTyp__Objec__17F790F9");
            });

            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.HasKey(e => e.OtId)
                    .HasName("PK__Overtime__E2E4CBBAD0CFE6B8");

                entity.Property(e => e.Otdate)
                    .HasColumnType("date")
                    .HasColumnName("OTDate");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Overtimes)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Overtimes__EmpId__1DB06A4F");

                entity.HasOne(d => d.OtStatusNavigation)
                    .WithMany(p => p.Overtimes)
                    .HasForeignKey(d => d.OtStatus)
                    .HasConstraintName("FK__Overtimes__OtSta__1EA48E88");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__USERS__AF2DBB993782BD8B");

                entity.ToTable("USERS");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserStatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatus)
                    .HasConstraintName("FK__USERS__UserStatu__1AD3FDA4");
            });

            modelBuilder.Entity<VOvertime>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOvertimes");

                entity.Property(e => e.April).HasColumnName("APRIL");

                entity.Property(e => e.Aug).HasColumnName("AUG");

                entity.Property(e => e.Dec).HasColumnName("DEC");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Feb).HasColumnName("FEB");

                entity.Property(e => e.Jan).HasColumnName("JAN");

                entity.Property(e => e.July).HasColumnName("JULY");

                entity.Property(e => e.June).HasColumnName("JUNE");

                entity.Property(e => e.March).HasColumnName("MARCH");

                entity.Property(e => e.May).HasColumnName("MAY");

                entity.Property(e => e.Nov).HasColumnName("NOV");

                entity.Property(e => e.Oct).HasColumnName("OCT");

                entity.Property(e => e.Sept).HasColumnName("SEPT");

                entity.Property(e => e.TotalOverTime).HasColumnName("Total_OverTime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
