using System;
using LandscapingCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LandscapingCompany.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Firm> Firm { get; set; }
        public virtual DbSet<ParkDecorators> ParkDecorators { get; set; }
        public virtual DbSet<ParkZones> ParkZones { get; set; }
        public virtual DbSet<Parks> Parks { get; set; }
        public virtual DbSet<PlantWatering> PlantWatering { get; set; }
        public virtual DbSet<Plants> Plants { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=pbv;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firm>(entity =>
            {
                entity.ToTable("firm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ParkDecorators>(entity =>
            {
                entity.ToTable("park_decorators");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("character varying");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("character varying");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasColumnType("character varying");

                entity.Property(e => e.EducationFacilityName)
                    .HasColumnName("education_facility_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ParkZones>(entity =>
            {
                entity.ToTable("park_zones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.ParkId).HasColumnName("park_id");

                entity.HasOne(d => d.Park)
                    .WithMany(p => p.ParkZones)
                    .HasForeignKey(d => d.ParkId)
                    .HasConstraintName("park_zones_park_id_fkey");
            });

            modelBuilder.Entity<Parks>(entity =>
            {
                entity.ToTable("parks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<PlantWatering>(entity =>
            {
                entity.HasKey(e => new { e.PlantAge, e.PlantType })
                    .HasName("plant_watering_pkey");

                entity.ToTable("plant_watering");

                entity.Property(e => e.PlantAge).HasColumnName("plant_age");

                entity.Property(e => e.PlantType)
                    .HasColumnName("plant_type")
                    .HasColumnType("character varying");

                entity.Property(e => e.Litres).HasColumnName("litres");

                entity.Property(e => e.Regularity).HasColumnName("regularity");

                entity.Property(e => e.WateringTime)
                    .HasColumnName("watering_time")
                    .HasColumnType("time without time zone");
            });

            modelBuilder.Entity<Plants>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ParkZone })
                    .HasName("plants_pkey");

                entity.ToTable("plants");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ParkZone).HasColumnName("park_zone");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.PlantType)
                    .HasColumnName("plant_type")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantingDate)
                    .HasColumnName("planting_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => new { e.WorkerId, e.PlantId, e.PlantWateringTime })
                    .HasName("schedule_pkey");

                entity.ToTable("schedule");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.Property(e => e.PlantId).HasColumnName("plant_id");

                entity.Property(e => e.PlantWateringTime)
                    .HasColumnName("plant_watering_time")
                    .HasColumnType("time without time zone");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirmId).HasColumnName("firm_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.FirmId)
                    .HasConstraintName("services_firm_id_fkey");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.ToTable("workers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("character varying");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
