using AdminTools.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminTools.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        // Asset related classes
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetHistory> Asset_History { get; set; }
        public DbSet<BusinessLookup> BusinessUnits { get; set; }
        public DbSet<LocationLookup> Locations { get; set; }
        public DbSet<ModelLookup> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().HasAlternateKey(c => c.AssetTag);
            modelBuilder.Entity<Asset>().HasAlternateKey(c => c.SerialNumber);
        }

    }

}
