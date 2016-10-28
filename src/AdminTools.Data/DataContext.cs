using AdminTools.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminTools.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }


		// Change related classes
        public DbSet<Change> Changes { get; set; }
        public DbSet<RiskLevel> Risk { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }

}
