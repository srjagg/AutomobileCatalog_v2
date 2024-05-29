using AutomobileCatalog.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomobileCatalog.Persistense.ModelsConfiguration
{
    public class BrandsConfiguration : IEntityTypeConfiguration<Brands>
    {
        public void Configure(EntityTypeBuilder<Brands> builder)
        {
            builder.ToTable(nameof(Brands));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(20);

            builder.HasMany(u => u.Cars)
              .WithOne(o => o.Brands)
              .HasForeignKey(o => o.BrandId);
        }
    }
}
