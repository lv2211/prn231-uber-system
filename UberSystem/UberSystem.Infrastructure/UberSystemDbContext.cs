using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UberSystem.Domain.Entities;
using UberSystem.Infrastructure.Configurations;
using UberSystem.Infrastructure.Data;

namespace UberSystem.Infrastructure
{
    public class UberSystemDbContext : DbContext
    {
        public UberSystemDbContext()
        {    
        }

        public UberSystemDbContext(DbContextOptions<UberSystemDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }
        
        public DbSet<Rating> Ratings { get; set; }
        
        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<Driver> Drivers { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<Cab> Cabs { get; set; }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            return configuration.GetConnectionString("Default") ?? string.Empty;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString(), options =>
            {
                options.CommandTimeout(120);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entity relationship configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DriverConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RatingConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TripConfiguration).Assembly);
            #endregion

            #region Seeding data files
            modelBuilder.SeedCabInfo();
            modelBuilder.SeedCustomerInfo();
            modelBuilder.SeedDriverInfo();
            modelBuilder.SeedUserInfo();
            #endregion
        }
    }
}
