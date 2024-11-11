using Microsoft.EntityFrameworkCore;
using DataProject.Models;
using DataProjectDb.Models;

namespace DataProject.Data
{
    public class DataProjectDbContext : DbContext
    {
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<Victim> Victims { get; set; }
        public DbSet<Offence> Offences { get; set; }
        public DbSet<OffenceVictim> OffenceVictims { get; set; }

        // Constructor
        public DataProjectDbContext(DbContextOptions options) : base(options) { }

        // Configuring the relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-many relationship between Criminal and Offence
            modelBuilder.Entity<Offence>()
                .HasOne(o => o.Criminal)
                .WithMany(c => c.Offences)
                .HasForeignKey(o => o.CriminalId);

            // Many-to-many relationship between Offence and Victim through OffenceVictim
            modelBuilder.Entity<OffenceVictim>()
                .HasKey(ov => new { ov.OffencesId, ov.VictimId });

            modelBuilder.Entity<OffenceVictim>()
                .HasOne(ov => ov.Offence)
                .WithMany(o => o.OffenceVictims)
                .HasForeignKey(ov => ov.OffencesId);

            modelBuilder.Entity<OffenceVictim>()
                .HasOne(ov => ov.Victim)
                .WithMany(v => v.OffenceVictims)
                .HasForeignKey(ov => ov.VictimId);

            // seeding data 
             DbHelper.SeedData(modelBuilder); 
        }
    }
}
