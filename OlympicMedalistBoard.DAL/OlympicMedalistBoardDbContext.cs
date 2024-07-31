using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OlympicMedalistBoard.Models;
namespace OlympicMedalistBoard.DAL
{
    public class OlympicMedalistBoardDbContext : IdentityDbContext<IdentityUser>
    {
        public OlympicMedalistBoardDbContext(DbContextOptions<OlympicMedalistBoardDbContext> options) : base(options)
        {
        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Medal> Medals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.ToTable("Athletes");
                entity.HasKey(a => a.AthleteID);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Birthdate).IsRequired();

                entity.HasOne(a => a.Country)
                      .WithMany(c => c.Athletes)
                      .HasForeignKey(a => a.CountryID)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Sport)
                      .WithMany(s => s.Athletes)
                      .HasForeignKey(a => a.SportID)
                      .OnDelete(DeleteBehavior.NoAction); 
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sports");
                entity.HasKey(s => s.SportID);
                entity.Property(s => s.SportName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");
                entity.HasKey(c => c.CountryID);
                entity.Property(c => c.CountryName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.CountryCode).IsRequired().HasMaxLength(2);
            });

            modelBuilder.Entity<Medal>(entity =>
            {
                entity.ToTable("Medals");
                entity.HasKey(m => m.MedalID);
                entity.Property(m => m.MedalType).IsRequired().HasMaxLength(10);
                entity.Property(m => m.DateAwarded).IsRequired();

                entity.HasOne(m => m.Athlete)
                      .WithMany(a => a.Medals)
                      .HasForeignKey(m => m.AthleteID)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(m => m.Sport)
                      .WithMany(s => s.Medals)
                      .HasForeignKey(m => m.SportID)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}