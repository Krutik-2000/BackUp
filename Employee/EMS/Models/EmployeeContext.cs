using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EMS.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<ObjectType> ObjectTypes { get; set; }
        public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }
        public virtual DbSet<TypeOfObject> TypeOfObjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VwSalaryCount> VwSalaryCounts { get; set; }
        public virtual DbSet<VwabsentCount> VwabsentCounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC0765\\MSSQL2019;Database=Employee;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Attendance1).HasColumnName("Attendance");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Attendance1Navigation)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Attendance1)
                    .HasConstraintName("FK__Attendanc__Atten__5812160E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Attendanc__UserI__59063A47");
            });

            modelBuilder.Entity<ObjectType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK__ObjectTy__9A61929162566A8C");

                entity.ToTable("ObjectType");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonalDetail>(entity =>
            {
                entity.HasKey(e => e.PersonalDetailsId)
                    .HasName("PK__Personal__52B544529E548036");

                entity.Property(e => e.PersonalDetailsId).HasColumnName("PersonalDetails_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email_Id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("Hire_Date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MobileNumber)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Mobile_Number");

                entity.Property(e => e.ProfileImage)
                    .IsUnicode(false)
                    .HasColumnName("Profile_Image");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.PersonalDetailDepartmentNavigations)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__PersonalD__Depar__534D60F1");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.PersonalDetailGenderNavigations)
                    .HasForeignKey(d => d.Gender)
                    .HasConstraintName("FK__PersonalD__Gende__5165187F");

                entity.HasOne(d => d.MaritalStatusNavigation)
                    .WithMany(p => p.PersonalDetailMaritalStatusNavigations)
                    .HasForeignKey(d => d.MaritalStatus)
                    .HasConstraintName("FK__PersonalD__Marit__52593CB8");

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.PersonalDetailPostNavigations)
                    .HasForeignKey(d => d.Post)
                    .HasConstraintName("FK__PersonalDe__Post__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonalDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PersonalD__UserI__5535A963");
            });

            modelBuilder.Entity<TypeOfObject>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__TypeOfOb__516F03B545595416");

                entity.ToTable("TypeOfObject");

                entity.Property(e => e.Value)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.TypeOfObjects)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("FK__TypeOfObj__Objec__4BAC3F29");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK__Users__Role__4E88ABD4");
            });

            modelBuilder.Entity<VwSalaryCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwSalaryCount");

                entity.Property(e => e.PerDaySalary).HasColumnName("perDaySalary");
            });

            modelBuilder.Entity<VwabsentCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VWAbsentCount");

                entity.Property(e => e.Month).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
