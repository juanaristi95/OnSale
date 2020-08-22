using Microsoft.EntityFrameworkCore;
using OnSale.Common.Entities;

namespace OnSale.Web.Data
{
    // herence 
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Properties

        // Generic property
        public DbSet<Country> Countries { get; set; }

        // method to prevent repeted countries
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // has an Index by field Name and that field is unique
            modelBuilder.Entity<Country>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }

    }
}
