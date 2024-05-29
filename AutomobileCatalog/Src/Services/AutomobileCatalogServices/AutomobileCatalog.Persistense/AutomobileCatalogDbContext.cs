using AutomobileCatalog.Models.Models;
using AutomobileCatalog.Persistense.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutomobileCatalog.Persistense
{
    public class AutomobileCatalogDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AutomobileCatalogDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private DbSet<Cars> Cars { get; set; }
        private DbSet<Brands> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DBCnxSqlServer");

                if (string.IsNullOrEmpty(connectionString))
                    throw new InvalidOperationException("Connection string not found");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarsConfiguration());
            modelBuilder.ApplyConfiguration(new BrandsConfiguration());
        }
    }
}
