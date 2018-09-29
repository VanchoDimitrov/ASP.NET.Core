using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDReactJSEntityFramework.Models
{
    public partial class TrainingDatabaseContext : DbContext
    {
        public TrainingDatabaseContext()
        {
        }

        public TrainingDatabaseContext(DbContextOptions<TrainingDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCities> TblCities { get; set; }
        public virtual DbSet<TblEmployees> TblEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your 
                //connection string, you should move it out of source code. 
                //See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance 
                //on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TrainingDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("tblCities");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEmployees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployees");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Department)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasMaxLength(6);

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
