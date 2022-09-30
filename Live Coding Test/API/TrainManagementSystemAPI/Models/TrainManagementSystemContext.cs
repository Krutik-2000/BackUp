using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrainManagementSystemAPI.Models
{
    public partial class TrainManagementSystemContext : DbContext
    {
        public TrainManagementSystemContext()
        {
        }

        public TrainManagementSystemContext(DbContextOptions<TrainManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StationTrain> StationTrains { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC0765\\MSSQL2019;Database=TrainManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.HasOne(d => d.FromStationNavigation)
                    .WithMany(p => p.BookingFromStationNavigations)
                    .HasForeignKey(d => d.FromStation)
                    .HasConstraintName("FK__Booking__FromSta__5629CD9C");

                entity.HasOne(d => d.ToStationNavigation)
                    .WithMany(p => p.BookingToStationNavigations)
                    .HasForeignKey(d => d.ToStation)
                    .HasConstraintName("FK__Booking__ToStati__571DF1D5");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TrainId)
                    .HasConstraintName("FK__Booking__TrainId__5812160E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Booking__UserId__59063A47");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StationTrain>(entity =>
            {
                entity.ToTable("Station_Train");

                entity.Property(e => e.StationTrainId).HasColumnName("Station_TrainId");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationTrains)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK__Station_T__Stati__534D60F1");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.StationTrains)
                    .HasForeignKey(d => d.TrainId)
                    .HasConstraintName("FK__Station_T__Train__52593CB8");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("Train");

                entity.Property(e => e.TrainName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
