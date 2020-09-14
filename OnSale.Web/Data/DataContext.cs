using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnSale.Common.Entities;
using OnSale.Web.Data.Entities;

namespace OnSale.Web.Data
{
    // herence 
    public class DataContext : IdentityDbContext<User>
    {
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Properties

        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }
        // Generic property
        public DbSet<Country> Countries { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }


        // method to prevent repeted countries
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(t => t.Name)
                .IsUnique();


            modelBuilder.Entity<Country>(cou =>
            {
                cou.HasIndex("Name").IsUnique();
                cou.HasMany(c => c.Departments).WithOne(d => d.Country).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Department>(dep =>
            {
                dep.HasIndex("Name", "CountryId").IsUnique();
                dep.HasOne(d => d.Country).WithMany(c => c.Departments).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<City>(cit =>
            {
                cit.HasIndex("Name", "DepartmentId").IsUnique();
                cit.HasOne(c => c.Department).WithMany(d => d.Cities).OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Product>()
                .HasIndex(t => t.Name)
                .IsUnique();


        }

    }

}

