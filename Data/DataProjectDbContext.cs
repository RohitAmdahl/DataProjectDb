using DataProject.Models;
using DataProjectDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProject.Data
{
    public class DataProjectDbContext : DbContext
    {
        public DbSet<Criminal> criminals { get; set; }
        public DbSet<Victim> victims { get; set; }

        public DbSet<Offense> Offenses { get; set; }

        // Create a constructor
        public DataProjectDbContext(DbContextOptions options) : base(options) { }

        //override - OnModelcreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Call seed data method to initialize with data
            DbHelper.SeedData(modelBuilder);
          
        }


    }
}
